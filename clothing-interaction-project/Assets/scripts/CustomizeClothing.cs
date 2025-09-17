using UnityEngine;
using UnityEngine.UI;
public class CustomizeClothing : MonoBehaviour
{
    public GameObject clothing;
    public GameObject pattern;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // todo: should check if clothing and pattern is empty or not 
        
        if (clothing != null && pattern != null)
        {
            clothing.gameObject.transform.GetChild(0).GetComponent<RawImage>().texture = pattern.gameObject.transform.GetChild(0).GetComponent<RawImage>().texture;
            pattern = null;
        }

    }
}
