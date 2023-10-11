using UnityEngine;

public class ClickToChangeSprite : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2;

    private SpriteRenderer spriteRenderer;
    private bool canInteract = true; // Flag to control interactions

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (canInteract)
        {
            ChangeSprite();
        }
    }

    public void ChangeSprite()
    {
        if (spriteRenderer.sprite == sprite1)
        {
            spriteRenderer.sprite = sprite2;
        }
        else
        {
            spriteRenderer.sprite = sprite1;
        }
    }

    public void SetInteract(bool state)
    {
        canInteract = state;
    }
}
