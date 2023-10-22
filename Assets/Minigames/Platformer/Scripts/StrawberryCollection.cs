using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrawberryCollection : MonoBehaviour
{
    public static int strawberry = 0;
    [SerializeField] private Text strawberryText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            Destroy(collision.gameObject);
            strawberry++;
        }
    }
}