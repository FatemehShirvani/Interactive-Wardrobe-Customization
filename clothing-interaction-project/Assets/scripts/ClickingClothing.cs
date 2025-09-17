using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickingClothing : MonoBehaviour
{

    public CustomizeClothing customizeClothing;

    public Material OutlineMaterial; // assign your white shader material in inspector
    public float OutlineScale = 1.1f; // how much bigger the outline should be

    private void Awake()
    {
        customizeClothing = Object.FindFirstObjectByType<CustomizeClothing>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }



    // todo: show visually that it is selected (green border or something)
    private void OnMouseDown()
    {
        // This is called when the user clicks on the collider
        Debug.Log("Clothing selected " + gameObject.name);

        customizeClothing.clothing = gameObject;

        if (customizeClothing.currentOutline != null)
        {
            customizeClothing.currentOutline.SetActive(false);
        }
        Transform outlineTransform = transform.Find("Outline");
        
        if (outlineTransform != null)
        {
            outlineTransform.gameObject.SetActive(true);
            
            customizeClothing.currentOutline = outlineTransform.gameObject;
        }
        // TODO: create outline as a child SpriteRenderer

    }

}
