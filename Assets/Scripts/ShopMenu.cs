using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    private Button feedButton;
    private TextMeshProUGUI foodName;
    public GameObject foodObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnFood()
    {
        Instantiate(foodObject, foodObject.transform.position, foodObject.transform.rotation);
    }

    public void NextFood()
    {
        // Scroll to next food
    }
}
