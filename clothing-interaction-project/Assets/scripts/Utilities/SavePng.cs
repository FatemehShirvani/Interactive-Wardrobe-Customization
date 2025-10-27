using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using SimpleFileBrowser;
using System;

public class SavePng : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject mainBody;

    public Button saveButton;

    void Start()
    {
        Button btn = saveButton.GetComponent<Button>();
        btn.onClick.AddListener(Capture);
    }


    public void Capture()
    {
        StartCoroutine(CaptureCoroutine());

    }

    public Camera captureCamera;

    public IEnumerator CaptureCoroutine()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Image Files", ".png"));
        FileBrowser.SetDefaultFilter(".png");
        
        yield return FileBrowser.WaitForSaveDialog(
            pickMode: FileBrowser.PickMode.Files,
            allowMultiSelection: false,
            initialPath: null,
            initialFilename: "ScreenshotCharacter.png",
            title: "Save Character",
            saveButtonText: "Save"
        );
        

        if (FileBrowser.Success && FileBrowser.Result.Length > 0)
        {
            string path = FileBrowser.Result[0];
            if (!path.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                path += ".png";


            yield return new WaitForEndOfFrame();

            var renderers = mainBody.GetComponentsInChildren<SpriteRenderer>();
            if (renderers.Length == 0)
            {
                Debug.LogWarning("No SpriteRenderers found to capture!");
                yield break;
            }

            Bounds bounds = renderers[0].bounds;
            foreach (var r in renderers)
                bounds.Encapsulate(r.bounds);

            // Convert world bounds to screen-space rectangle
            Vector3 minScreen = captureCamera.WorldToScreenPoint(bounds.min);
            Vector3 maxScreen = captureCamera.WorldToScreenPoint(bounds.max);

            float x = Mathf.Min(minScreen.x, maxScreen.x);
            float y = Mathf.Min(minScreen.y, maxScreen.y);
            float width = Mathf.Abs(maxScreen.x - minScreen.x);
            float height = Mathf.Abs(maxScreen.y - minScreen.y);
            float margin = 0.1f; 
            x += width * 0.3f * 0.5f;
            y += height * margin * 0.5f;
            width *= 1f - 0.3f;
            height *= 1f - margin;
            
            if (width <= 0 || height <= 0)
            {
                Debug.LogWarning("Height or width not valid");
                yield break;
            }

            Rect rect = new Rect(x, y, width, height);

            Texture2D tex = new Texture2D((int)width, (int)height, TextureFormat.RGB24, false);
            tex.ReadPixels(rect, 0, 0);
            tex.Apply();

            // string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), "character.png");
            File.WriteAllBytes(path, tex.EncodeToPNG());

            Debug.Log($"Screenshot saved to: {path}");

            Destroy(tex);
        }
    }

}
