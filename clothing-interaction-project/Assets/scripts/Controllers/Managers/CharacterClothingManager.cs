using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class CharacterClothingManager : MonoBehaviour
{
    public SpriteRenderer topRenderer;
    public SpriteRenderer bottomRenderer;

    public HangerInteractable currentlyEquippedTop;
    public HangerInteractable currentlyEquippedBottom;
    public List<HangerInteractable> allTops;
    public List<HangerInteractable> allBottoms;

    void Awake()
    {
        HangerInteractable[] allClothing = FindObjectsOfType<HangerInteractable>(true);

        allTops = allClothing.Where(c => c.type == ClothingType.Top).ToList();
        allBottoms = allClothing.Where(c => c.type == ClothingType.Bottom).ToList();
    }
    public void PutClothingOnCharacter(HangerInteractable clothing)
    {
        if (clothing.type == ClothingType.Bottom)
        {

            // if a bottom is already equipped, return it to the rack
            if (bottomRenderer.sprite != null)
            {
                HangerInteractable previous = currentlyEquippedBottom;

                if (previous != null)
                    previous.ReturnToRack();
            }
            currentlyEquippedBottom = clothing;
            bottomRenderer.GetComponent<SpriteRenderer>().sprite = clothing.GetComponent<SpriteRenderer>().sprite;
            bottomRenderer.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = clothing.GetComponent<SpriteRenderer>().sprite;
            clothing.gameObject.SetActive(false);

        }
        if (clothing.type == ClothingType.Top)
        {
            if (topRenderer.sprite != null)
            {
                HangerInteractable previous = currentlyEquippedTop;

                if (previous != null)
                    previous.ReturnToRack();
            }
            currentlyEquippedTop = clothing;
            topRenderer.GetComponent<SpriteRenderer>().sprite = clothing.GetComponent<SpriteRenderer>().sprite;
            //for outline
            topRenderer.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = clothing.GetComponent<SpriteRenderer>().sprite;
            clothing.gameObject.SetActive(false);

        }

    }
    public void EquipTopByName(string name)
    {
        HangerInteractable top = allTops.FirstOrDefault(t => t.name == name);
        if (top != null) PutClothingOnCharacter(top);
    }

    public void EquipBottomByName(string name)
    {
        HangerInteractable bottom = allBottoms.FirstOrDefault(b => b.name == name);
        if (bottom != null) PutClothingOnCharacter(bottom);
    }
    
    
}
