using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickingClothing : MonoBehaviour, IPointerClickHandler
{

    public CustomizeClothing customizeClothing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

   
      
        // todo: show visually that it is selected (green border or something)
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clothing selected " + gameObject.name);
        customizeClothing.clothing = gameObject;
    }
}
