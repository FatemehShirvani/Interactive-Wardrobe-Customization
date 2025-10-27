using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using SimpleFileBrowser;
using System;

public class HelpOption : MonoBehaviour
{
    public Button helpButton;

    public Button exitCanvas;

    public Canvas helpCanvas;

    private void Awake()
    {
        helpButton.onClick.AddListener(OpenCanvas);
    
        exitCanvas.onClick.AddListener(CloseCanvas);
        helpCanvas.enabled = false;
    }

    public void OpenCanvas()
    {
        Debug.Log("huii");
        helpCanvas.enabled = true;
    }

    public void CloseCanvas()
    {
        helpCanvas.enabled = false;
    }

}