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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button characterBtn = characterButton.GetComponent<Button>();
        characterBtn.onClick.AddListener(SwitchToCharacter);


        Button clothingBtn = closetButton.GetComponent<Button>();
        clothingBtn.onClick.AddListener(SwitchToCloset);


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchToCloset()
    {
        characterCanvas.SetActive(false);
        characterPartElements.SetActive(false);
        closetCanvas.SetActive(true);
        closetPartElements.SetActive(true);
    }
    
    public void SwitchToCharacter()
    {
        characterCanvas.SetActive(true);
        characterPartElements.SetActive(true);
        closetCanvas.SetActive(false);
        closetPartElements.SetActive(false);
    }
}
