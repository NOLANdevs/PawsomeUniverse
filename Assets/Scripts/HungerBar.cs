using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public Gradient gradient;
    public Image fill;
    public Slider hungerSlider;
    private int maxHunger = 20;
    private int initialHunger;

    private int currentFedAmount = 0;

    private float startTime = 5.0f;
    public float delay = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Trigger hunger decay over time
        InvokeRepeating("ReduceHunger", startTime, delay);

        // Set initial values
        initialHunger = maxHunger / 2;
        hungerSlider.maxValue = maxHunger;
        currentFedAmount = initialHunger;
        hungerSlider.value = currentFedAmount;

        // Set fill colour to be proportional to the fill percentage
        hungerSlider.fillRect.gameObject.SetActive(true);
        fill.color = gradient.Evaluate(hungerSlider.normalizedValue);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FeedAnimal(int amount)
    {
        // Check if new total will be under max
        if (!(currentFedAmount + amount > maxHunger))
        {
            currentFedAmount += amount;
        } else
        {
            // If over max add up to max value
            currentFedAmount += maxHunger - currentFedAmount;
        }

        // Set fill colour to be proportional to the fill percentage
        hungerSlider.value = currentFedAmount;
        fill.color = gradient.Evaluate(hungerSlider.normalizedValue);
    }

    public void ReduceHunger()
    {
        // Decay hunger by 1
        hungerSlider.value--;
        fill.color = gradient.Evaluate(hungerSlider.normalizedValue);
    }
}

