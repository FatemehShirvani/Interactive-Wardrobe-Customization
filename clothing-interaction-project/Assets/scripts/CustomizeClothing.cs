using UnityEngine;
using UnityEngine.UI;
public class CustomizeClothing : MonoBehaviour
{
    public GameObject clothing;
    public GameObject currentOutline;


    private Material clothingMaterial;
    private SpriteRenderer clothingRenderer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }
    
    public void SetClothing(GameObject newClothing)
{
    clothing = newClothing;
    clothingRenderer = clothing.GetComponent<SpriteRenderer>();

        if (clothingRenderer != null)
        {
            // Use an instance of the material so we don't modify the shared one
            clothingMaterial = Instantiate(clothingRenderer.material);
            clothingRenderer.material = clothingMaterial;
        }
    }


    // Update is called once per frame

    void Update()
    {
     
    }

    public void ApplyColor(Color color)
    {

        if (clothingMaterial == null) return;
        
        clothingMaterial.SetFloat("_UsePattern", 0f);
        clothingMaterial.SetColor("_Color", color);
    } 


    public void ApplyPattern(Texture2D patternTexture)
    {
        Debug.Log("heree");
        if (clothingMaterial == null || patternTexture == null) return;
        clothingMaterial.SetFloat("_UsePattern", 1f);
        clothingMaterial.SetTexture("_PatternTex", patternTexture);
    

        // float patternScale = 2
        // clothingMaterial.SetVector("_PatternScale", patternScale);
    }
}



