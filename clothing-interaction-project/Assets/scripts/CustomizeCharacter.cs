using UnityEditor.Embree;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeCharacter : MonoBehaviour
{

    public GameObject mainBody;
    public GameObject bodyTypeSelected;
    public GameObject hairstyleSelected;

    public GameObject currentOutline;

    public GameObject colorSelected;


    public GameObject character;
    public GameObject characterOutline;


    private Material characterMaterial;
    private SpriteRenderer characterRenderer;

    private Material characterOutlineMaterial;
    private SpriteRenderer characterOutlineRenderer;

    public GameObject hair;

    private Material hairMaterial;
    private SpriteRenderer hairRenderer;

    public PartType selectedPart; // currently selected part

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
         characterRenderer = character.GetComponent<SpriteRenderer>();
        if (characterRenderer != null)
        {
            // Use an instance of the material so we don't modify the shared one
            characterMaterial = Instantiate(characterRenderer.material);
            characterRenderer.material = characterMaterial;
        }

        characterOutlineRenderer = characterOutline.GetComponent<SpriteRenderer>();
        if (characterOutlineRenderer != null)
        {
            // Use an instance of the material so we don't modify the shared one
            characterOutlineMaterial = Instantiate(characterOutlineRenderer.material);
            characterOutlineRenderer.material = characterOutlineMaterial;
        }

        hairRenderer = hair.GetComponent<SpriteRenderer>();
        if (hairRenderer != null)
        {
            // Use an instance of the material so we don't modify the shared one
            hairMaterial = Instantiate(hairRenderer.material);
            hairRenderer.material = hairMaterial;
        }

        Color defaultSkintone = new Color(0.80f, 0.60f, 0.45f);
        ApplyColor(defaultSkintone);
    }

    // Update is called once per frame
    void Update()
    {


        if (mainBody != null && colorSelected != null)
        {
            // ApplyColor();
            colorSelected = null;

        }

        if (bodyTypeSelected == null) return;

        SpriteRenderer bodyRenderer = bodyTypeSelected.GetComponent<SpriteRenderer>();
        if (bodyRenderer == null) return;

        SpriteRenderer mainBodyRenderer = mainBody.transform.GetChild(0).GetComponent<SpriteRenderer>();
        if (mainBodyRenderer == null) return;

        mainBodyRenderer.sprite = bodyRenderer.sprite;


        if (hairstyleSelected == null) return;
        SpriteRenderer hairstyleRenderer = hairstyleSelected.GetComponent<SpriteRenderer>();

        if (hairstyleRenderer == null) return;


        SpriteRenderer mainBodyHairstyleRenderer = mainBody.transform.GetChild(2).GetComponent<SpriteRenderer>();
        if (mainBodyHairstyleRenderer == null) return;

        mainBodyHairstyleRenderer.sprite = hairstyleRenderer.sprite;


    }
        
    // public void ApplyColor(Color color)
    // {
    //     if (characterMaterial == null) return;
    //     characterMaterial.SetFloat("_UsePattern", 0f);
    //     characterMaterial.SetColor("_Color", color);

    //     characterOutlineMaterial.SetFloat("_UsePattern", 0f);

    //     if (characterOutlineMaterial == null) return;
    //     Color darker = color * 0.7f;
    //     characterOutlineMaterial.SetFloat("_UsePattern", 0f);
    //     characterOutlineMaterial.SetColor("_Color", darker);
    // }
    public void ApplyColor(Color color)
{
    if (selectedPart == null) return;

    if (selectedPart == PartType.Body)
    {
        if (characterMaterial != null)
        {
            characterMaterial.SetFloat("_UsePattern", 0f);
            characterMaterial.SetColor("_Color", color);
        }

        if (characterOutlineMaterial != null)
        {
            Color darker = color * 0.7f;
            characterOutlineMaterial.SetFloat("_UsePattern", 0f);
            characterOutlineMaterial.SetColor("_Color", darker);
        }
    }
    else if (selectedPart == PartType.Hair)
        {
        if (hairMaterial != null)
        {
            hairMaterial.SetFloat("_UsePattern", 0f);
            hairMaterial.SetColor("_Color", color);
        }

            // if (hairOutlineMaterial != null)
            // {
            //     Color darker = color * 0.7f;
            //     hairOutlineMaterial.SetFloat("_UsePattern", 0f);
            //     hairOutlineMaterial.SetColor("_Color", darker);
            // }
        
    
    }
}

}
