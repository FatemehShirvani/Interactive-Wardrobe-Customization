using UnityEditor.Embree;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeCharacterManager : MonoBehaviour
{

    public GameObject mainBody;
    public GameObject bodyTypeSelected;
    public GameObject hairstyleSelected;

    public GameObject leftBodyOutline;
    public GameObject leftHairOutline;


    public GameObject character;
    public GameObject characterOutline;
    public GameObject noseOutline;
    public GameObject hair;

    public SpriteRenderer mainBodyGreenOutline;
    public SpriteRenderer mainHairGreenOutline;



    private Material characterMaterial;
    private Material characterOutlineMaterial;
    private Material noseOutlineMaterial;


    private Material hairMaterial;

    public PartType selectedPart; // currently selected part
    private SelectablePart[] selectableParts;

    void Awake()
    {
        selectableParts = FindObjectsOfType<SelectablePart>();

        characterMaterial = InstantiateMaterial(character);
        characterOutlineMaterial = InstantiateMaterial(characterOutline);
        noseOutlineMaterial = InstantiateMaterial(noseOutline);
        hairMaterial = InstantiateMaterial(hair);

        Color defaultSkintone = new Color(0.80f, 0.60f, 0.45f);
        ApplyColor(defaultSkintone, PartType.Body);


    }

    private Material InstantiateMaterial(GameObject obj)
    {
        if (obj == null) return null;
        var renderer = obj.GetComponent<SpriteRenderer>();
        if (renderer == null) return null;
        Material mat = Instantiate(renderer.material);
        renderer.material = mat;
        return mat;
    }

    public void SelectPart(SelectablePart part)
    {
        selectedPart = part.partType;
        if (part.partType == PartType.Body)
        {
            UpdateBodySprite(part.gameObject);
        }else if (part.partType == PartType.Hair)
        {
            UpdateHairstyleSprite(part.gameObject);
        }
    }

    public void UpdateBodySprite(GameObject gameObject)
    {
        Debug.Log($"UpdateBodySprite selected {gameObject.name}");
        bodyTypeSelected = gameObject;

        if (bodyTypeSelected == null || mainBody == null) return;

        SpriteRenderer bodyRenderer = bodyTypeSelected.GetComponent<SpriteRenderer>();
        if (bodyRenderer == null) return;

        SpriteRenderer mainBodyRenderer = mainBody.transform.GetChild(0).GetComponent<SpriteRenderer>();
        if (mainBodyRenderer == null) return;

        mainBodyRenderer.sprite = bodyRenderer.sprite;

        if (characterMaterial != null)
            mainBodyRenderer.material = characterMaterial;
    }


   
    public void UpdateHairstyleSprite(GameObject gameObject)
    {
         Debug.Log($"UpdateHairstyleSprite selected {gameObject.name}");
        hairstyleSelected = gameObject;
        if (hairstyleSelected == null || mainBody == null) return;

        SpriteRenderer hairstyleRenderer = hairstyleSelected.GetComponent<SpriteRenderer>();
        if (hairstyleRenderer == null) return;

        SpriteRenderer mainBodyHairstyleRenderer = mainBody.transform.GetChild(2).GetComponent<SpriteRenderer>();
        if (mainBodyHairstyleRenderer == null) return;

        mainBodyHairstyleRenderer.sprite = hairstyleRenderer.sprite;
    

        if (this.hairMaterial != null)
            mainBodyHairstyleRenderer.material = hairMaterial;
    }

    public void UpdateBodySprite(Sprite sprite)
    {
        if (sprite == null || mainBody == null) return;

        SpriteRenderer mainBodyRenderer = mainBody.transform.GetChild(0).GetComponent<SpriteRenderer>();
        if (mainBodyRenderer == null) return;

        mainBodyRenderer.sprite = sprite;
        
        if (characterMaterial != null)
            mainBodyRenderer.material = characterMaterial;
    }



   
   public void UpdateHairstyleSprite(Sprite sprite)
    {
        if (sprite == null || mainBody == null) return;

        SpriteRenderer mainBodyHairstyleRenderer = mainBody.transform.GetChild(2).GetComponent<SpriteRenderer>();
        if (mainBodyHairstyleRenderer == null) return;

        mainBodyHairstyleRenderer.sprite = sprite;

        if (hairMaterial != null)
            mainBodyHairstyleRenderer.material = hairMaterial;
    }


    public void ApplyColor(Color color, PartType type)
    {

        if (type == PartType.Body)
        {
            SetBodyColor(color);
        }
        else if (type == PartType.Hair)
        {
            SetHairColor(color);
        }
    }
    
    public void ApplyToMaterial(Material material, Color color)
    {
        material.SetFloat("_UsePattern", 0f);
        material.SetColor("_Color", color);
    }

    public void HighlightSelected(SelectablePart selected)
    {
        foreach (var part in selectableParts)
        {
            part.SetOutline(part == selected);
        }
    }

    public Color GetBodyColor(){
        return characterMaterial != null ? characterMaterial.GetColor("_Color") : Color.white;
    }
    public Color GetHairColor()
    {
        return hairMaterial != null ? hairMaterial.GetColor("_Color") : Color.white;
    }

    public string GetBodySpriteName()
    {
        SpriteRenderer bodyRenderer = bodyTypeSelected.GetComponent<SpriteRenderer>();
        if (bodyRenderer == null || bodyRenderer.sprite == null) return null;
        return bodyRenderer.sprite.name;
    }

    public string GetHairSpriteName()
    {
        SpriteRenderer hairRenderer = hairstyleSelected.GetComponent<SpriteRenderer>();
        if (hairRenderer == null || hairRenderer.sprite == null) return null;
        return hairRenderer.sprite.name;
    }
    

  
    public void SetBodyColor(Color c) {
   
            if (characterMaterial != null)
        {
            // Main body
            ApplyToMaterial(characterMaterial, c);
        }

        if (characterOutlineMaterial != null)
        {
            // Outline (slightly darker)
            Color darker = c * 0.7f;
            ApplyToMaterial(characterOutlineMaterial, darker);
            ApplyToMaterial(noseOutlineMaterial, darker);

            
            
        }
    
    }
    public void SetHairColor(Color c)
    {
        if (hairMaterial != null)
        {
            ApplyToMaterial(hairMaterial, c);
        }
    }

    public void RefreshMainOutlines()
    {
                SpriteRenderer mainBodyRenderer = mainBody.transform.GetChild(0).GetComponent<SpriteRenderer>();

        if (mainBodyGreenOutline != null && mainBodyRenderer != null)
            mainBodyGreenOutline.sprite = mainBodyRenderer.sprite;
        SpriteRenderer hairRenderer = hair.GetComponent<SpriteRenderer>();

        if (mainHairGreenOutline != null && hairRenderer != null)
            mainHairGreenOutline.sprite = hairRenderer.sprite;
    }
        
}
