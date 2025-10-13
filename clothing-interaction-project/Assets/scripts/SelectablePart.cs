using UnityEngine;

    public enum PartType { Body, Hair }


public class SelectablePart : MonoBehaviour
{
    public PartType partType;

    public CustomizeCharacter customizeCharacter;
    void OnMouseDown()
    {
        Debug.Log("clicked on:" + partType);
        customizeCharacter.selectedPart = partType;
    }

}