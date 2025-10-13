using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleFileBrowser;
using System.Collections;
using System.IO;

public class CreateRightPanel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Canvas canva;

    public RectTransform colorContainer;
    public RectTransform patternContainer;


    public GameObject prefabColor;
    public GameObject prefabPattern;

    public Button importButton;

	

    List<Color> colors = new List<Color> {
        // new Color(1, 1, 1), new Color(1, 0, 1),new Color(1, 0, 0), new Color(1, 1, 0), // random - test
        new Color(0.78f, 0.87f, 0.94f), new Color(0.86f, 0.80f, 0.94f), new Color(0.95f, 0.78f, 0.87f), new Color(0.98f, 0.78f, 0.79f), new Color(0.97f, 0.85f, 0.77f), new Color(0.98f, 0.93f, 0.80f), new Color(0.79f, 0.89f, 0.87f), // pastels
        
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
    public void AddPattern(Texture2D texture)
    {
        if (texture == null) return;
texture.wrapMode = TextureWrapMode.Repeat;

        textures.Add(texture);

        GameObject pattern = Instantiate(prefabPattern, patternContainer);
        RawImage colorRaw = pattern.transform.GetChild(0).GetComponent<RawImage>();
        colorRaw.texture = texture;
    }


    // Update is called once per frame
    void Update()
    {

    }

    
    void TaskOnClick()
    {
        // TODO open file chooser; import img, pass it through pixel art thingy; add it as circle
       
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Images", ".jpg", ".png"), new FileBrowser.Filter("Text Files", ".txt", ".pdf"));

        FileBrowser.SetDefaultFilter(".jpg");

        FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");


        StartCoroutine(ShowLoadDialogCoroutine());
    }
    
	IEnumerator ShowLoadDialogCoroutine()
	{
	
		yield return FileBrowser.WaitForLoadDialog( FileBrowser.PickMode.Files, true, null, null, "Select Files", "Load" );


		if( FileBrowser.Success )
			OnFilesSelected( FileBrowser.Result ); // FileBrowser.Result is null, if FileBrowser.Success is false
	}
	
	void OnFilesSelected( string[] filePaths )
	{
		string filePath = filePaths[0];

        Texture2D texture = new Texture2D(2, 2);
      
        byte[] fileData = File.ReadAllBytes(filePath);
        
        if (texture.LoadImage(fileData))
        {
            AddPattern(texture);
            Debug.Log("Texture successfully loaded and added: " + filePath);
        }
        else
        {
            Debug.LogError("Failed to load texture: " + filePath);
        }
	}
}
