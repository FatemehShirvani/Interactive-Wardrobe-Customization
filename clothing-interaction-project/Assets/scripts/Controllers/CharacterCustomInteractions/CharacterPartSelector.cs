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

    public GameObject mainBodyOutline;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        if (partType == CharacterPartType.Body)
        {
            characterManager.UpdateBodySprite(gameObject);
        }
        else if (partType == CharacterPartType.Hair)
        {
            
            characterManager.UpdateHairstyleSprite(gameObject);
            if (mainBodyOutline != null)
                mainBodyOutline.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;

        }


        if (characterManager.currentOutline != null)
            characterManager.currentOutline.SetActive(false);

        Transform outlineTransform = transform.Find("Outline");
        if (outlineTransform != null)
        {
            outlineTransform.gameObject.SetActive(true);
            characterManager.currentOutline = outlineTransform.gameObject;
        }
    }

}
