using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using System;
public class ClickingColor: MonoBehaviour, IPointerClickHandler
{

    public CustomizeClothing customizeClothing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        customizeClothing = FindFirstObjectByType<CustomizeClothing>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // todo: show visually that it is selected (green border or something)
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Color selected " + gameObject.name);
        customizeClothing.clickedObject = gameObject;
        customizeClothing.type = TypeEnum.color;
    }
}
