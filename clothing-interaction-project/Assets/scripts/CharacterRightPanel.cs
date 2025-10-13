using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterRightPanel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Canvas canva;

    public RectTransform colorContainer;

    public GameObject prefabColor;

   List<Color> colors = new List<Color> {
    new Color(1.00f, 0.89f, 0.77f), // light ivory
    new Color(0.96f, 0.80f, 0.68f), // fair
    new Color(0.89f, 0.70f, 0.55f), // light tan
    new Color(0.80f, 0.60f, 0.45f), // medium
    new Color(0.70f, 0.52f, 0.36f), // olive / light brown
    new Color(0.56f, 0.38f, 0.26f), // brown
    new Color(0.42f, 0.28f, 0.20f), // deep brown
    new Color(0.30f, 0.20f, 0.14f), // dark brown
    new Color(0.20f, 0.13f, 0.09f)  // very dark / ebony
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


    }

    // Update is called once per frame
    void Update()
    {

    }
}
