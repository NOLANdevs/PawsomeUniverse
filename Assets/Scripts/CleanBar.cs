using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanBar : MonoBehaviour
{
    public Gradient gradient;
    public Image fill;
    public Slider cleanlinessSlider;
    public int maxCleanliness = 20;
    private int initialCleanliness = 10; 

    private int currentCleanliness;

    private float startTime = 5.0f;
    public float decayDelay = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

        // Trigger cleanliness decay over time
        InvokeRepeating("DecayCleanliness", startTime, decayDelay);

        // Set fill colour to be proportional to the fill percentage
        cleanlinessSlider.fillRect.gameObject.SetActive(true);
        fill.color = gradient.Evaluate(cleanlinessSlider.normalizedValue);

        // Initialize cleanliness
        currentCleanliness = initialCleanliness;
        cleanlinessSlider.maxValue = maxCleanliness;
        cleanlinessSlider.value = currentCleanliness;
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any additional update logic here if needed.
    }

    public void CleanAnimal(int amount)
    {
        // Increase cleanliness by the specified amount
        currentCleanliness += amount;

        // Ensure cleanliness doesn't exceed the maximum
        currentCleanliness = Mathf.Clamp(currentCleanliness, 0, maxCleanliness);

        // Update the cleanliness slider and UI color
        cleanlinessSlider.value = currentCleanliness;
        fill.color = gradient.Evaluate(cleanlinessSlider.normalizedValue);
    }

    private void DecayCleanliness()
    {
        // Decrease cleanliness by 1 (adjust the decay rate as needed)
        currentCleanliness--;

        // Update the cleanliness slider and UI color
        cleanlinessSlider.value = currentCleanliness;
        fill.color = gradient.Evaluate(cleanlinessSlider.normalizedValue);
    }
}
