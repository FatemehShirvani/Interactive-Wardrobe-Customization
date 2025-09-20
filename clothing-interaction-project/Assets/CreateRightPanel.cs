using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRightPanel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Canvas canva;

    public RectTransform colorContainer;
    public RectTransform patternContainer;


    public GameObject prefabColor;
    public GameObject prefabPattern;

    List<Color> colors = new List<Color> {
        // new Color(1, 1, 1), new Color(1, 0, 1),new Color(1, 0, 0), new Color(1, 1, 0), // random - test
        new Color(0.78f, 0.87f, 0.94f), new Color(0.86f, 0.80f, 0.94f), new Color(0.95f, 0.78f, 0.87f), new Color(0.98f, 0.78f, 0.79f), new Color(0.97f, 0.85f, 0.77f), new Color(0.98f, 0.93f, 0.80f), new Color(0.79f, 0.89f, 0.87f), // pastels
        
    };

    public List<Texture> textures = new List<Texture>();
    void Start()
    {

        foreach (Color c in colors)
        {
            GameObject color = Instantiate(prefabColor, colorContainer);
            RawImage colorRaw = color.transform.GetChild(0).GetComponent<RawImage>();
            colorRaw.color = c;
        }


        Texture[] loadedTextures = Resources.LoadAll<Texture2D>("patterns");
        textures.AddRange(loadedTextures);
        
        foreach (Texture t in textures)
        {
            GameObject pattern = Instantiate(prefabPattern, patternContainer);
            RawImage colorRaw = pattern.transform.GetChild(0).GetComponent<RawImage>();
            colorRaw.texture = t;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
