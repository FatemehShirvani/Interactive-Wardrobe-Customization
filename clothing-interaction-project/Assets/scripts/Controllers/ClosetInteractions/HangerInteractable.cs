using System.Collections.Generic;
using UnityEngine;

public enum ClothingType { Top, Bottom /*, Shoes, Hat, etc. */ }


public class HangerInteractable : MonoBehaviour
{
    public List<GameObject> clothes; // all hangers in order
    public int indexClickedHanger;                // index of clicked hanger

    private bool isDragging = false;

    private Vector3 originalPosition; // remember original positions

    private Vector3 mouseDownPos;
    public GameObject closetObject;

    private enum DragMode { None, SlideHanger, PickUp }
    private DragMode dragMode = DragMode.None;

    public Collider2D characterCollider;


    public ClothingType type;


    public CharacterClothingManager characterManager;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void OnMouseDown()
    {

        isDragging = true;
        mouseDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        isDragging = false;

        if (dragMode == DragMode.PickUp)
        {
            Vector2 clothingPos = clothes[indexClickedHanger].transform.position;

            if (characterCollider.OverlapPoint(clothingPos))
            {
                characterManager.PutClothingOnCharacter(this);

            }
            else
            {
                clothes[indexClickedHanger].transform.position = originalPosition;
            }
        }

        dragMode = DragMode.None;

    }

    private void Update()
    {
        if (!isDragging) return;

        Vector3 mousePos = Input.mousePosition;

        // we need this to convert mousePosition to world position since our clothes are in worldSpace
        float zDepth = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        mousePos.z = zDepth;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 mouseDelta = (Vector2)Input.mousePosition - (Vector2)mouseDownPos;

        if (dragMode == DragMode.None)
        {
            float horizontalThreshold = 5f; // pixels
            float verticalThreshold = 5f;   // pixels

            if (Mathf.Abs(mouseDelta.x) > horizontalThreshold)
                dragMode = DragMode.SlideHanger;
            else if (Mathf.Abs(mouseDelta.y) > verticalThreshold)
                dragMode = DragMode.PickUp;
        }



        if (dragMode == DragMode.SlideHanger)
        {
            DragHangers(mouseWorldPos);
        }

        if (dragMode == DragMode.PickUp)
        {
            Vector3 pos = clothes[indexClickedHanger].transform.position;
            pos = mouseWorldPos; // or clamp it to some range above the rack
            clothes[indexClickedHanger].transform.position = pos;

        }


    }
    public void DragHangers(Vector3 mouseWorldPos)
    {
        SpriteRenderer closetRenderer = closetObject.GetComponent<SpriteRenderer>();
        float leftBound = closetRenderer.bounds.min.x;
        float rightBound = closetRenderer.bounds.max.x;
        float margin = 1.2f;


        Vector3 pos = clothes[indexClickedHanger].transform.position;
        // pos.x = mouseWorldPos.x;
        float spacing = 0.8f;

        // i added this so that they don't end up all overlapped 
        float maxRight = rightBound - margin;
        for (int i = clothes.Count - 1; i > indexClickedHanger; i--)
            maxRight -= spacing;

        float minLeft = leftBound + margin;
        for (int i = 0; i < indexClickedHanger; i++)
            minLeft += spacing;
        pos.x = Mathf.Clamp(mouseWorldPos.x, minLeft, maxRight);


        clothes[indexClickedHanger].transform.position = pos;

        float smoothFactor = 10f;

        if (Input.mousePosition.x >= (mouseDownPos.x + 5)) // DRAG ON RIGHT
        {
            for (int i = indexClickedHanger + 1; i < clothes.Count; i++)
            {
                if (clothes[i].transform.position.x - clothes[indexClickedHanger].transform.position.x < spacing)
                {
                    // Vector3 pos2 = clothes[i].transform.position;
                    // pos2.x += spacing;
                    // pos2.x = Mathf.Min(pos2.x, rightBound - margin);

                    // clothes[i].transform.position = pos2;
                    Vector3 pos2 = clothes[i].transform.position;

                    float x = pos2.x + spacing;
                    x = Mathf.Min(x, rightBound - margin); // keep within bounds

                    pos2.x = Mathf.Lerp(pos2.x, x, Time.deltaTime * smoothFactor);

                    clothes[i].transform.position = pos2;

                }
            }
        }
        else if (Input.mousePosition.x <= (mouseDownPos.x - 5)) // DRAG ON LEFT
        {
            for (int i = indexClickedHanger - 1; i >= 0; i--)

                if (clothes[i].transform.position.x > clothes[indexClickedHanger].transform.position.x - spacing)
                {
                    // Vector3 pos2 = clothes[i].transform.position;
                    // pos2.x -= spacing;
                    // pos2.x = Mathf.Max(pos2.x, leftBound + margin);


                    // clothes[i].transform.position = pos2;
                    Vector3 pos2 = clothes[i].transform.position;

                    float x = pos2.x - spacing;
                    x = Mathf.Min(x, leftBound - margin); // keep within bounds

                    pos2.x = Mathf.Lerp(pos2.x, x, Time.deltaTime * smoothFactor);

                    clothes[i].transform.position = pos2;
                }

        }
    }

    public void ReturnToRack()
    {
        Debug.Log("returned to rack");
        transform.position = originalPosition;
        gameObject.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().material.SetColor("_Color", new Color(1,1,1));
    }
}