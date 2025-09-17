using UnityEngine;
using UnityEngine.UI;
public class CustomizeClothing : MonoBehaviour
{
    public GameObject clothing;
    public GameObject pattern;
    public GameObject currentOutline; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
{
    
    if (clothing != null && pattern != null)
        {
            RawImage patternRaw = pattern.transform.GetChild(0).GetComponent<RawImage>();
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

            // reset selected pattern
            pattern = null;
        }
}


}
