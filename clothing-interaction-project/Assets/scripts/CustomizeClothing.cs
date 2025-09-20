using UnityEngine;
using UnityEngine.UI;
public class CustomizeClothing : MonoBehaviour
{
    public GameObject clothing;
    public GameObject clickedObject;
    public GameObject currentOutline;

    public TypeEnum type;


    public
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {

        if (clothing != null && clickedObject != null)
        {
            if (type == TypeEnum.color)
            {
                Debug.Log("color type");
                ApplyColor();
            }
            else if (type == TypeEnum.pattern)
            {
                Debug.Log("pattern type");
                ApplyPattern();
            }

            // reset selected pattern
            clickedObject = null;
        }

        void ApplyColor()
        {
            SpriteRenderer clothingRenderer = clothing.GetComponent<SpriteRenderer>();
            if (clothingRenderer == null) return;

            SpriteRenderer patternRenderer = clothing.transform.Find("Pattern").GetComponent<SpriteRenderer>();
            if (patternRenderer == null) return;

            Texture2D tex = new Texture2D(1, 1);
            tex.SetPixel(0, 0, Color.white);
            tex.Apply();

            Sprite whiteSprite = Sprite.Create(
                tex,
                new Rect(0, 0, tex.width, tex.height),
                new Vector2(0.5f, 0.5f),
                clothingRenderer.sprite.pixelsPerUnit
            );

            patternRenderer.sprite = whiteSprite;
            patternRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

            Vector2 clothingSize = clothingRenderer.sprite.bounds.size;
            Vector2 patternSize = patternRenderer.sprite.bounds.size;
            patternRenderer.transform.localScale = new Vector3(
                clothingSize.x / patternSize.x,
                clothingSize.y / patternSize.y,
                1f
            );
            patternRenderer.transform.localPosition = Vector3.zero;

            RawImage patternRaw = clickedObject.transform.GetChild(0).GetComponent<RawImage>();

            patternRenderer.color = patternRaw.color;
        }


        void ApplyPattern()
        {

            RawImage patternRaw = clickedObject.transform.GetChild(0).GetComponent<RawImage>();

            if (patternRaw == null || patternRaw.texture == null) return;

            Texture2D tex = patternRaw.texture as Texture2D;

            SpriteRenderer clothingRenderer = clothing.GetComponent<SpriteRenderer>();
            if (clothingRenderer == null) return;

            Sprite newSprite = Sprite.Create(
                tex,
                new Rect(0, 0, tex.width, tex.height),
                new Vector2(0.5f, 0.5f),
                clothingRenderer.sprite.pixelsPerUnit
            );

            SpriteRenderer patternRenderer = clothing.transform.Find("Pattern").GetComponent<SpriteRenderer>();
            if (patternRenderer == null) return;

            patternRenderer.color = Color.white; // reset the color if previously we selected a color
            patternRenderer.sprite = newSprite;
            patternRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

            // Scale the pattern to match the clothing size
            Vector2 clothingSize = clothingRenderer.sprite.bounds.size;
            Vector2 patternSize = patternRenderer.sprite.bounds.size;
            patternRenderer.transform.localScale = new Vector3(
                clothingSize.x / patternSize.x,
                clothingSize.y / patternSize.y,
                1f
            );
            patternRenderer.transform.localPosition = Vector3.zero;

        }
    }


}
