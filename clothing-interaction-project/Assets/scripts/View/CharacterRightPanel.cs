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
    // skin tones
    new Color(1.00f, 0.89f, 0.77f), // light ivory
    new Color(0.96f, 0.80f, 0.68f), // fair
    new Color(0.89f, 0.70f, 0.55f), // light tan
    new Color(0.80f, 0.60f, 0.45f), // medium
    new Color(0.70f, 0.52f, 0.36f), // olive / light brown
    new Color(0.56f, 0.38f, 0.26f), // brown
    new Color(0.42f, 0.28f, 0.20f), // deep brown

    new Color(0.30f, 0.20f, 0.14f), // dark brown
    new Color(0.20f, 0.13f, 0.09f), // very dark / ebony
    new Color(0.08f, 0.08f, 0.08f), // jet black
    new Color(0.40f, 0.25f, 0.15f), // medium brown
    new Color(0.65f, 0.45f, 0.25f), // light brown
    new Color(0.90f, 0.75f, 0.45f), // golden blonde
    new Color(0.95f, 0.85f, 0.55f), // blonde

    new Color(0.85f, 0.50f, 0.40f), // copper red

       new Color(1.00f, 0.00f, 0.00f), // bright red
    new Color(1.00f, 0.35f, 0.15f), // fiery orange
    new Color(1.00f, 0.70f, 0.10f), // gold / yellow
    new Color(0.20f, 0.85f, 0.20f), // bright green
    new Color(0.00f, 0.80f, 0.70f), // teal
    new Color(0.25f, 0.40f, 0.90f), // bright blue

    new Color(0.40f, 0.80f, 1.00f), // sky blue
    new Color(0.60f, 0.20f, 0.85f), // violet
    new Color(0.90f, 0.10f, 0.60f), // hot pink
    new Color(0.95f, 0.65f, 0.45f), // strawberry blonde (fits near orange-pink)
    new Color(0.75f, 0.30f, 0.10f), // auburn (deep warm red-brown)

    new Color(0.30f, 0.30f, 0.30f), // silver / grey
    new Color(0.95f, 0.95f, 0.95f)  // platinum white
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
