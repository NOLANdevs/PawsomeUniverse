using UnityEngine;


public class ClickToToggleLight : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D light2D;  // Assign the 2D light GameObject in the Inspector

    private void Start()
    {
        // Make sure to assign the Light2D component in the Inspector
        if (light2D == null)
        {
            Debug.LogWarning("Light2D component not assigned!");
        }
    }

    private void OnMouseDown()
    {
        // Toggle the light on and off
        if (light2D != null)
        {
            light2D.enabled = !light2D.enabled;
        }
    }
}
