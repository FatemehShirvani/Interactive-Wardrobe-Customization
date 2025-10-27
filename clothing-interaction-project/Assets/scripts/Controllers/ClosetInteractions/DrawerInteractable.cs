using UnityEngine;

public class DrawerMouseEvent : MonoBehaviour
{
    public bool isTop;
    public bool closed;
    public GameObject openedTopDoor;
    public GameObject openedBottomDoor;
    public GameObject closedTopDoor;
    public GameObject closedBottomDoor;
    private Vector3 mouseDownPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        // This is called when the user clicks on the collider
        Debug.Log("drawer selected " + gameObject.name);
        mouseDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        if (closed)
        {
            if (isTop)
            {
                if (Input.mousePosition.y <= (mouseDownPos.y - 0))
                {
                    gameObject.SetActive(false);
                    openedTopDoor.SetActive(true);
                }
            }
            else
            { // Bottom door
                if (Input.mousePosition.y <= (mouseDownPos.y + 0))
                {
                    gameObject.SetActive(false);
                    openedBottomDoor.SetActive(true);
                }

            }
        }
        else // OPENED
        {
            if (isTop)
            {
                if (Input.mousePosition.y >= (mouseDownPos.y + 0))
                {
                    gameObject.SetActive(false);
                    closedTopDoor.SetActive(true);
                }
            }
            else
            { // Bottom door
                if (Input.mousePosition.y >=(mouseDownPos.y - 0)) // TODO see if we add dragging (just -20 instead or not)
                {
                    gameObject.SetActive(false);
                    closedBottomDoor.SetActive(true);
                }

            }
        }

    }
}
