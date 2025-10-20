using UnityEngine;
using UnityEngine.UI;

public class SwitchScene : MonoBehaviour
{
    public Button characterButton;
    public Button closetButton;

    public GameObject characterCanvas;
    public GameObject closetCanvas;

    public GameObject characterPartElements;

    public GameObject closetPartElements;

    private SelectablePart[] selectableParts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterButton.onClick.AddListener(SwitchToCharacter);


        closetButton.onClick.AddListener(SwitchToCloset);
        selectableParts = FindObjectsOfType<SelectablePart>();
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchToCloset()
    {
        SetCanvasState(false);
   
    }

    public void SwitchToCharacter()
    {
        SetCanvasState(true);
      
    }
    private void SetCanvasState(bool isCharacterMode)
    {
        characterCanvas.SetActive(isCharacterMode);
        characterPartElements.SetActive(isCharacterMode);
        closetCanvas.SetActive(!isCharacterMode);
        closetPartElements.SetActive(!isCharacterMode);
        selectableParts = FindObjectsOfType<SelectablePart>(true);
        foreach (var part in selectableParts)
        {
            if (part.partType == PartType.Body || part.partType == PartType.Hair)
            {
                part.SetInteractable(isCharacterMode);
            }
            else if (part.partType == PartType.Top || part.partType == PartType.Bottom)
            {
                part.SetInteractable(!isCharacterMode);
            }
        
        }
    }
}
