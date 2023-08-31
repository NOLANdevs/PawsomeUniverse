using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public Gradient gradient;
    public Image fill;
    public Slider hungerSlider;
    public int amountToBeFed;

    private int currentFedAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        hungerSlider.maxValue = amountToBeFed;
        hungerSlider.value = 0;
        fill.color = gradient.Evaluate(0f);
        hungerSlider.fillRect.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FeedAnimal(int amount)
    {
        if (!(currentFedAmount + amount > amountToBeFed))
        {
            currentFedAmount += amount;
        }
        else
        {
            currentFedAmount += amountToBeFed - currentFedAmount;
        }

        hungerSlider.fillRect.gameObject.SetActive(true);
        fill.color = gradient.Evaluate(hungerSlider.normalizedValue);
        hungerSlider.value = currentFedAmount;
    }
}

