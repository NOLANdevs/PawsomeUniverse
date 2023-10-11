using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ClickToToggleLight : MonoBehaviour
{
    public Light2D light2D;  
    private bool canInteract = true; // Flag to control interactions

    private void Start()
    {
        if (light2D == null)
        {
            Debug.LogWarning("Light2D component not assigned!");
        }
    }

    private void OnMouseDown()
    {
        if (canInteract && light2D != null)
        {
            ToggleLight();
        }
    }

    public void ToggleLight()
    {
        if (light2D != null)
        {
            light2D.enabled = !light2D.enabled;
        }
    }

    public void SetInteract(bool state)
    {
        canInteract = state;
    }
}
