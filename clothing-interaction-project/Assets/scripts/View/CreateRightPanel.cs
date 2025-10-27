using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleFileBrowser;
using System.Collections;
using System.IO;
using System;
public class CreateRightPanel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public RectTransform colorContainer;
     public RectTransform colorAdviceContainer;
    public RectTransform patternContainer;


    public GameObject prefabColor;
    public GameObject prefabPattern;

    public Button importButton;




    List<Color> colors = new List<Color> {
        new Color(0.78f, 0.87f, 0.94f), new Color(0.86f, 0.80f, 0.94f), new Color(0.95f, 0.78f, 0.87f), new Color(0.98f, 0.78f, 0.79f), new Color(0.97f, 0.85f, 0.77f), new Color(0.98f, 0.93f, 0.80f), new Color(0.79f, 0.89f, 0.87f), // pastels
        
        new Color(1.00f, 1.00f, 1.00f),
        new Color(0.50f, 0.50f, 0.50f),
        new Color(0.00f, 0.00f, 0.00f),

        new Color(0.20f, 0.55f, 0.95f),
        new Color(0.60f, 0.30f, 0.95f),
        new Color(0.95f, 0.20f, 0.55f),
        new Color(0.95f, 0.25f, 0.25f),
        new Color(0.98f, 0.55f, 0.15f),
        new Color(1.00f, 0.90f, 0.00f),
        new Color(0.00f, 0.80f, 0.70f)
    };

    public List<Texture> textures = new List<Texture>();
    void Start()
    {
        Button btn = importButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        foreach (Color c in colors)
        {
            GameObject color = Instantiate(prefabColor, colorContainer);
            RawImage colorRaw = color.transform.GetChild(0).GetComponent<RawImage>();
            colorRaw.color = c;
        }


        Texture2D[] loadedTextures = Resources.LoadAll<Texture2D>("patterns");

        foreach (Texture2D tex in loadedTextures)
        {
            AddPattern(tex);
        }

    }

    Texture2D ApplyPixelation(Texture2D originalTexture, int targetWidthInPixels = 64)
    {
        if (originalTexture == null) return null;

        int width = originalTexture.width;
        int height = originalTexture.height;

        // Compute relative pixel block size
        int pixelSizeX = Mathf.Max(1, Mathf.CeilToInt((float)width / targetWidthInPixels));
        int pixelSizeY = pixelSizeX; // square blocks

        Texture2D pixelatedTexture = new Texture2D(width, height, TextureFormat.RGBA32, false);
        pixelatedTexture.filterMode = FilterMode.Point;

        for (int y = 0; y < height; y += pixelSizeY)
        {
            for (int x = 0; x < width; x += pixelSizeX)
            {
                Color avgColor = GetBlockAverageColor(originalTexture, x, y, pixelSizeX, pixelSizeY);

                for (int yy = 0; yy < pixelSizeY && (y + yy) < height; yy++)
                {
                    for (int xx = 0; xx < pixelSizeX && (x + xx) < width; xx++)
                    {
                        pixelatedTexture.SetPixel(x + xx, y + yy, avgColor);
                    }
                }
            }
        }

        pixelatedTexture.Apply();

        byte[] pngData = pixelatedTexture.EncodeToPNG();

        string savePath = Path.Combine(Application.persistentDataPath, "pixelated_image.png");
        File.WriteAllBytes(savePath, pngData);

        Debug.Log($"Saved pixelated image to: {savePath}");

        return pixelatedTexture;
    }

    Color GetBlockAverageColor(Texture2D tex, int startX, int startY, int blockWidth, int blockHeight)
    {
        Color sum = Color.black;
        int count = 0;
        int width = tex.width;
        int height = tex.height;

        for (int y = 0; y < blockHeight && (startY + y) < height; y++)
        {
            for (int x = 0; x < blockWidth && (startX + x) < width; x++)
            {
                sum += tex.GetPixel(startX + x, startY + y);
                count++;
            }
        }

        return sum / count;
    }

    public void AddPattern(Texture2D texture)
    {
        if (texture == null) return;
        
        texture.wrapMode = TextureWrapMode.Repeat;

        textures.Add(texture);

        GameObject pattern = Instantiate(prefabPattern, patternContainer);
        pattern.transform.SetSiblingIndex(1); // first child after button
        RawImage colorRaw = pattern.transform.GetChild(0).GetComponent<RawImage>();
        colorRaw.texture = texture;
    }


    // Update is called once per frame
    void Update()
    {

    }


    void TaskOnClick()
    {

        FileBrowser.SetFilters(true, new FileBrowser.Filter("Images", ".jpg", ".png", ".jpeg"), new FileBrowser.Filter("Text Files", ".txt", ".pdf"));

        FileBrowser.SetDefaultFilter(".jpg");

        FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");

        StartCoroutine(ShowLoadDialogCoroutine());
    }

    IEnumerator ShowLoadDialogCoroutine()
    {

        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, true, null, null, "Select Files", "Load");


        if (FileBrowser.Success)
            OnFilesSelected(FileBrowser.Result); // FileBrowser.Result is null, if FileBrowser.Success is false
    }

    void OnFilesSelected(string[] filePaths)
    {
        string filePath = filePaths[0];

        if (!File.Exists(filePath))
        {
            Debug.LogError("File not found: " + filePath);
            return;
        }

        byte[] fileData;
        try
        {
            fileData = File.ReadAllBytes(filePath);
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to read file: " + filePath + "\n" + e);
            return;
        }

        // Force a readable RGBA32 texture
        Texture2D texture = new Texture2D(2, 2, TextureFormat.RGBA32, false);

        if (!texture.LoadImage(fileData))
        {
            Debug.LogError("Failed to load texture (possibly unsupported JPG/PNG): " + filePath);
            return;
        }

        // Apply pixelation and add to UI
        Texture2D pixelTexture = ApplyPixelation(texture);
        AddPattern(pixelTexture);

        Debug.Log("Texture successfully loaded and added: " + filePath);
    }


    public void AddColorAdvice(List<Color> colors)
    {
        // to remove all previous advised colors
        for (int i = colorAdviceContainer.childCount - 1; i >= 0; i--)
        {
            Destroy(colorAdviceContainer.GetChild(i).gameObject);
        }
        foreach (Color c in colors)
        {
            GameObject color = Instantiate(prefabColor, colorAdviceContainer);
            RawImage colorRaw = color.transform.GetChild(0).GetComponent<RawImage>();
            colorRaw.color = c;
        }
    }
}