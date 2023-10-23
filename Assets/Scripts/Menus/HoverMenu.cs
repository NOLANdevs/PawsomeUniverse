using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMenu : MonoBehaviour
{
    public GameObject player;
    public float horizOffset = 2.1f;
    public float vertOffset = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Track player position
        transform.position = player.transform.position + new Vector3(horizOffset, vertOffset, 0);
    }

    public void Show()
    {
        // Flip if on other side
        if (player.transform.position.x > 0.0f)
        {
            horizOffset *= -1;
        }
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
