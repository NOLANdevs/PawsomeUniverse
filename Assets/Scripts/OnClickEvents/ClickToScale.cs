using System.Collections;
using UnityEngine;

public class ClickToScale : MonoBehaviour
{
    private float scaleSpeed = 12f; // speed of scaling
    private Vector3 originalScale; // original scale of sprite
    private bool isScaling = false; // check if scaling
    private float scaleNum = 0.005f;
    private Coroutine scaleCoroutine; // ref to scaling coroutine
    private bool canInteract = true; // Flag to control interactions

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void OnMouseDown()
    {
        if (canInteract && !isScaling)
        {
            // start scaling animation
            if (scaleCoroutine != null)
            {
                // If the previous animation is still running, stop the previous animation
                StopCoroutine(scaleCoroutine);
                ResetScale(); // reset scale to the original size
            }

            scaleCoroutine = StartCoroutine(ScaleSprite());
        }
    }

    private IEnumerator ScaleSprite()
    {
        isScaling = true;

        // scale down sprite
        while (transform.localScale.x > originalScale.x - scaleNum)
        {
            transform.localScale -= new Vector3(scaleNum, scaleNum, scaleNum) * scaleSpeed * Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalScale - new Vector3(scaleNum, scaleNum, scaleNum);

        // scale up sprite
        while (transform.localScale.x < originalScale.x + scaleNum)
        {
            transform.localScale += new Vector3(scaleNum, scaleNum, scaleNum) * scaleSpeed * Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalScale + new Vector3(scaleNum, scaleNum, scaleNum);

        isScaling = false;
    }

    private void ResetScale()
    {
        transform.localScale = originalScale;
    }

    public void SetInteract(bool state)
    {
        canInteract = state;
    }
}
