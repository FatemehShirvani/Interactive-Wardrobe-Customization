using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClothingSelector : MonoBehaviour
{
    public CustomizeClothing customizeClothing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CustomizeClothing[] allClothing = FindObjectsOfType<CustomizeClothing>(true);
        if (allClothing.Length > 0)
            customizeClothing = allClothing[0];

    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnMouseDown()
    {
        // This is called when the user clicks on the collider
        Debug.Log("Clothing selected " + gameObject.name);

        customizeClothing.SetClothing(gameObject);

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
    }

}
