using System.Collections;
using UnityEngine;

public class ScaleOnButtonClick : MonoBehaviour
{
    private float scaleSpeed = 12f; // speed of scaling

    private Vector3 originalScale; // og scale of sprite
    private bool isScaling = false; // check if scaling
    private float scaleNum = 0.005f;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void OnMouseDown()
    {
        if (!isScaling)
        {
            // start scaling animation
            StartCoroutine(ScaleSprite());
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

        // scale up the sprite
        while (transform.localScale.x < originalScale.x + scaleNum)
        {
            transform.localScale += new Vector3(scaleNum, scaleNum, scaleNum) * scaleSpeed * Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalScale + new Vector3(scaleNum, scaleNum, scaleNum);

        isScaling = false;
    }
}
