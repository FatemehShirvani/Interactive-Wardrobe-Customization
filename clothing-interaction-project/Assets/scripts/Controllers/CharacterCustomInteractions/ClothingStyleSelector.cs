using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using System;

using System.Collections.Generic;

public enum ColorType
{
    Color,
    Pattern
}
// clicking on color or pattern for the clothing piece
public class ClothingStyleSelector : MonoBehaviour, IPointerClickHandler
{

    public CustomizeClothing customizeClothing;

    public CreateRightPanel createRightPanel;

    private ColorAdvice colorAdvice;

    public ColorType colorType;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        if (customizeClothing == null)
            customizeClothing = FindObjectOfType<CustomizeClothing>(true);
        if (createRightPanel == null)
            createRightPanel = FindObjectOfType<CreateRightPanel>(true);

        colorAdvice = new ColorAdvice();

    }

    // Update is called once per frame
    void Update()
    {
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Color selected " + gameObject.name);
        RawImage patternRaw = transform.GetChild(0).GetComponent<RawImage>();
        if (patternRaw == null) return;

        if (colorType == ColorType.Color)
        {
            Color color = patternRaw.color;
            customizeClothing.ApplyColor(color);

            var advice = colorAdvice.GetAdvice(color);

            createRightPanel.AddColorAdvice(advice);

        }
        else if (colorType == ColorType.Pattern)
        {
            if (patternRaw.texture == null) return;

            Texture2D tex = patternRaw.texture as Texture2D;

            customizeClothing.ApplyPattern(tex);
        }
    }


}
