using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public Animal animal;
    public Gradient gradient;
    public Image fill;
    public Slider hungerSlider;

    public float initialHunger = 0.5f;
    public float hungerDecayAmount = 0.05f;

    private float startTime = 5.0f;
    public float delay = 10.0f;

    void Start()
    {
        // Trigger hunger decay over time
        InvokeRepeating("ReduceHunger", startTime, delay);

        // Set initial values
        hungerSlider.value = fromPercent(initialHunger);
        hungerSlider.maxValue = fromPercent(1);

        // Set fill colour to be proportional to the fill percentage
        hungerSlider.fillRect.gameObject.SetActive(true);
        fill.color = gradient.Evaluate(hungerSlider.normalizedValue);
    }

    void Update()
    {
        // Set fill colour to be proportional to the fill percentage
        hungerSlider.value = fromPercent(animal.hunger);
        fill.color = gradient.Evaluate(hungerSlider.normalizedValue);
    }

    public void FeedAnimal(float amount)
    {
        // Increase hunger
        animal.hunger += amount;
        animal.hunger = Mathf.Clamp(animal.hunger, 0, 1);
    }

    public void ReduceHunger()
    {
        // Decay hunger
        animal.hunger -= hungerDecayAmount;
        animal.hunger = Mathf.Clamp(animal.hunger, 0, 1);
    }

    private float fromPercent(float pct)
    {
        return pct * 100;
    }
}

