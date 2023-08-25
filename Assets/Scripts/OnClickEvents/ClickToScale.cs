using System.Collections;
using UnityEngine;

public class ScaleOnButtonClick : MonoBehaviour
{
    public float minScale = 0.5f;  // Minimum scale when shrunk
    public float maxScale = 2f;    // Maximum scale when expanded
    public float scaleSpeed = 1f;  // Speed of scaling

    private Vector3 originalScale; // Original scale of the sprite
    private bool isShrinking = false; // Track if sprite is shrinking

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void OnMouseDown() {
                    if (!isShrinking)
            {
                // Start shrinking coroutine
                StartCoroutine(ShrinkSprite());
            }
    }

    private IEnumerator ShrinkSprite()
    {
        isShrinking = true;

        // Shrink the sprite
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * scaleSpeed;
            transform.localScale = Vector3.Lerp(originalScale, new Vector3(minScale, minScale, minScale), t);
            yield return null;
        }

        // Expand the sprite
        t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * scaleSpeed;
            transform.localScale = Vector3.Lerp(new Vector3(minScale, minScale, minScale), originalScale, t);
            yield return null;
        }

        isShrinking = false;
    }
}
