using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectHairstyle : MonoBehaviour
{
    public CustomizeCharacter customizeCharacter;

    public Material OutlineMaterial; // assign your white shader material in inspector
    public float OutlineScale = 1.2f; // how much bigger the outline should be

    // private void Awake()
    // {
    // }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        customizeCharacter = FindFirstObjectByType<CustomizeCharacter>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        // This is called when the user clicks on the collider
        Debug.Log("Hairstyle selected " + gameObject.name);

        customizeCharacter.hairstyleSelected = gameObject;
    

        if (customizeCharacter.currentOutline != null)
        {
            customizeCharacter.currentOutline.SetActive(false);
        }
        Transform outlineTransform = transform.Find("Outline");
        
        if (outlineTransform != null)
        {
            outlineTransform.gameObject.SetActive(true);
            
            customizeCharacter.currentOutline = outlineTransform.gameObject;
        }
        // TODO: create outline as a child SpriteRenderer

    }

}
