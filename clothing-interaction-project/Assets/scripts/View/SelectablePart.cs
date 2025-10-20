using UnityEngine;


public class SelectablePart : MonoBehaviour
{
    public bool isInteractable = true;
    public PartType partType;

    public CustomizeCharacterManager customizeCharacter;

    public GameObject outline;

    public Collider2D col;

    void Awake()
    {
        outline = transform.Find("Outline")?.gameObject;
        col = GetComponent<Collider2D>();
    }
    
    public void SetInteractable(bool value)
    {
        isInteractable = value;
        if (outline != null) outline.SetActive(false);
        if (col != null) col.enabled = value;
    }

    void OnMouseDown()
    {
        if (!isInteractable) return;

        Debug.Log("clicked on:" + partType);

        customizeCharacter.SelectPart(this);

        customizeCharacter.HighlightSelected(this);
    }
    
    public void SetOutline(bool state)
    {
        if (outline != null) outline.SetActive(state);
    }

}