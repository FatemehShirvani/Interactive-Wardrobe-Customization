using UnityEngine;
using UnityEngine.UI;

public class CustomColorSelector: MonoBehaviour
{

    public CustomizeClothing customizeClothing;

    public CreateRightPanel createRightPanel;

    public FlexibleColorPicker flexibleColorPicker;

    public Button openButton;

    public bool openedCustom;

    public Button exitButton;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         if (customizeClothing == null) customizeClothing = FindObjectOfType<CustomizeClothing>(true);
        if (createRightPanel == null) createRightPanel = FindObjectOfType<CreateRightPanel>(true);

        if (openButton != null) openButton.onClick.AddListener(OpenPicker);
        if (exitButton != null) exitButton.onClick.AddListener(ClosePicker);

    }


    // Update is called once per frame
    void Update()
    {
        if (openedCustom)
        {
            Debug.Log("Color selected " + flexibleColorPicker.color);
            customizeClothing.ApplyColor(flexibleColorPicker.color);
        }
    }



    public void OpenPicker()
    {
        flexibleColorPicker.gameObject.SetActive(true);
        openedCustom = true;
    }
    
    void ClosePicker()
    {
        flexibleColorPicker.gameObject.SetActive(false);
        openedCustom = false;
    }
    
       
}