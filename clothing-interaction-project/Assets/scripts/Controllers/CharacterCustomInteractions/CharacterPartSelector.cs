using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum CharacterPartType { Body, Hair }

// select from the 3 body type and hairstyles
public class CharacterPartSelector : MonoBehaviour
{
    public CharacterPartType partType;
    public bool defaultSelected;

    public CustomizeCharacterManager characterManager;

    public GameObject mainBodyGreenOutline;
    public GameObject mainHairGreenOutline;
    public GameObject mainBodyOutline;

    void Start()
    {
        if (characterManager == null)
            characterManager = FindFirstObjectByType<CustomizeCharacterManager>();

        if (defaultSelected)
            Select();
    }

    private void OnMouseDown()
    {
        Select();
    }

    private void Select()
    {
        Debug.Log($"{partType} selected {gameObject.name}");
        Transform outlineTransform = transform.Find("Outline");

        if (partType == CharacterPartType.Body)
        {
            characterManager.UpdateBodySprite(gameObject);
            UpdatePartOutline(ref characterManager.leftBodyOutline, outlineTransform);  // outline of object in left panel

            if (mainBodyOutline != null)
            {
                mainBodyOutline.GetComponent<SpriteRenderer>().sprite = outlineTransform.gameObject.GetComponent<SpriteRenderer>().sprite;

            }
            if (mainBodyGreenOutline != null)
                mainBodyGreenOutline.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;

        }
        else if (partType == CharacterPartType.Hair)
        {
            characterManager.UpdateHairstyleSprite(gameObject);
            UpdatePartOutline(ref characterManager.leftHairOutline, outlineTransform);  // outline of object in left panel
            if (mainHairGreenOutline != null)
                mainHairGreenOutline.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;

        }
        
    }

    public void UpdatePartOutline(ref GameObject currentOutline, Transform newOutline)
    {
        if (currentOutline != null)
        {
             currentOutline.SetActive(false);
        }

        if (newOutline != null)
        {
            newOutline.gameObject.SetActive(true);
            currentOutline = newOutline.gameObject;
        }
    }

}
