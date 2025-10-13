using UnityEngine;

public class DoorMouseEvent : MonoBehaviour
{
    public bool isLeft;
    public bool closed;
    public GameObject openedLeftDoor;
    public GameObject openedRightDoor;
    public GameObject closedLeftDoor;
    public GameObject closedRightDoor;
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

        mouseDownPos = Input.mousePosition;


    }

    private void OnMouseUp()
    {
        Debug.Log("click released");
        Debug.Log(Input.mousePosition);
        Debug.Log(mouseDownPos);
        if (closed)
        {
            if (isLeft)
            {
                if (Input.mousePosition.x <= (mouseDownPos.x - 0))
                {
                    gameObject.SetActive(false);
                    openedLeftDoor.SetActive(true);
                }
            }
            else
            { // right door
                if (Input.mousePosition.x >= (mouseDownPos.x + 0))
                {
                    gameObject.SetActive(false);
                    openedRightDoor.SetActive(true);
                }

            }
        }
        else // OPENED
        {
            if (isLeft)
            {
                if (Input.mousePosition.x >= (mouseDownPos.x + 0))
                {
                    gameObject.SetActive(false);
                    closedLeftDoor.SetActive(true);
                }
            }
            else
            { // right door
                if (Input.mousePosition.x <=(mouseDownPos.x - 0)) // TODO see if we add dragging (just -20 instead or not)
                {
                    gameObject.SetActive(false);
                    closedRightDoor.SetActive(true);
                }

            }
        }

    }
}
