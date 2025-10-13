using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using System;
public class ClickingColoCharacter: MonoBehaviour, IPointerClickHandler
{
    
    public CustomizeCharacter customizeCharacter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        customizeCharacter = FindFirstObjectByType<CustomizeCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       
        RawImage patternRaw = transform.GetChild(0).GetComponent<RawImage>();
            Debug.Log("Color selected " + patternRaw.color);
        customizeCharacter.ApplyColor(patternRaw.color);
    }
}
