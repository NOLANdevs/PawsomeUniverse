using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanBar : MonoBehaviour
{
    public Animal animal;
    public Gradient gradient;
    public Image fill;
    public Slider cleanlinessSlider;
    public float cleanlinessDecayAmount = 0.05f;

    private float startTime = 5.0f;
    public float decayDelay = 10.0f;

    void Start()
    {
        // Trigger cleanliness decay over time
        InvokeRepeating("DecayCleanliness", startTime, decayDelay);

        // Set fill colour to be proportional to the fill percentage
        cleanlinessSlider.fillRect.gameObject.SetActive(true);
        fill.color = gradient.Evaluate(cleanlinessSlider.normalizedValue);

        // Initialize cleanliness
        cleanlinessSlider.value = fromPercent(animal.cleanliness);
        cleanlinessSlider.maxValue = fromPercent(1);
    }

    void Update()
    {
        // Update the cleanliness slider and UI color
        cleanlinessSlider.value = fromPercent(animal.cleanliness);
        fill.color = gradient.Evaluate(cleanlinessSlider.normalizedValue);
    }

    public void CleanAnimal(float amount)
    {
        // Increase cleanliness
        animal.cleanliness += amount;
        animal.cleanliness = Mathf.Clamp(animal.cleanliness, 0, 1);
    }

    private void DecayCleanliness()
    {
        // Decrease cleanliness
        animal.cleanliness -= cleanlinessDecayAmount;
        animal.cleanliness = Mathf.Clamp(animal.cleanliness, 0, 1);
    }

    private float fromPercent(float pct)
    {
        return pct * 100;
    }
}
