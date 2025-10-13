using System.Collections.Generic;
using UnityEngine;

public class CharacterClothingManager : MonoBehaviour
{
    public SpriteRenderer topRenderer;
    public SpriteRenderer bottomRenderer;

    public MovingHangers currentlyEquippedTop;
    public MovingHangers currentlyEquippedBottom;


    public void PutClothingOnCharacter(MovingHangers clothing)
    {
        if (clothing.type == ClothingType.Bottom)
        {

            // if a bottom is already equipped, return it to the rack
            if (bottomRenderer.sprite != null)
            {
                MovingHangers previous = currentlyEquippedBottom;
                
                if (previous != null)
                    previous.ReturnToRack(); 
            }
        currentlyEquippedBottom = clothing;
            bottomRenderer.GetComponent<SpriteRenderer>().sprite = clothing.GetComponent<SpriteRenderer>().sprite;
            bottomRenderer.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = clothing.GetComponent<SpriteRenderer>().sprite;
            // clothing.GetComponent<SpriteRenderer>().enabled = false;
            clothing.gameObject.SetActive(false);

        }
        if (clothing.type == ClothingType.Top)
        {
            if (topRenderer.sprite != null)
            {
                MovingHangers previous = currentlyEquippedTop;

                if (previous != null)
                    previous.ReturnToRack();
            }
            currentlyEquippedTop = clothing;
            topRenderer.GetComponent<SpriteRenderer>().sprite = clothing.GetComponent<SpriteRenderer>().sprite;
            //for outline
            topRenderer.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = clothing.GetComponent<SpriteRenderer>().sprite;
            // clothing.GetComponent<SpriteRenderer>().enabled = false;
            clothing.gameObject.SetActive(false);

        }

    }
    
    
}
