using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoveBar : MonoBehaviour
{
    public Animal animal;
    public Gradient gradient;
    public Image fill;
    public Slider loveSlider;

    public float initialLove = 0.2f;
    public float loveDecayAmount = 0.1f;

    private float startTime = 5.0f;
    public float delay = 10.0f;

    void Start()
    {
        // Trigger love decay over time
        InvokeRepeating("ReduceLove", startTime, delay);

        // Set initial values
        loveSlider.value = fromPercent(initialLove);
        loveSlider.maxValue = fromPercent(1);

        // Set fill colour to be proportional to the fill percentage
        loveSlider.fillRect.gameObject.SetActive(true);
        fill.color = gradient.Evaluate(loveSlider.normalizedValue);
    }

    void Update()
    {
        // Set fill colour to be proportional to the fill percentage
        loveSlider.value = fromPercent(animal.love);
        fill.color = gradient.Evaluate(loveSlider.normalizedValue);
    }

    public void PetAnimal(float amount)
    {
        // Increase hunger
        animal.love += amount;
        animal.love = Mathf.Clamp(animal.love, 0, 1);
    }

    public void ReduceLove()
    {
        // Decay Love
        animal.love -= loveDecayAmount;
        animal.love = Mathf.Clamp(animal.love, 0, 1);
    }

    private float fromPercent(float pct)
    {
        return pct * 100;
    }
}

