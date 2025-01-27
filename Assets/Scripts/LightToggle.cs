using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightToggle : MonoBehaviour
{
    public Light light; // Reference to the Light component
    public InputActionReference action; // Input action for toggling
    public Color originalColor; // Original color of the light
    public Color newColor; // New color to toggle to

    private bool isOriginalColor = true; // Flag to track the current color state

    private void Start()
    {
        // Get the Light component from the GameObject
        light = GetComponent<Light>();

        // Enable the input action
        action.action.Enable();

        // Set up the performed callback to toggle colors
        action.action.performed += (ctx) =>
        {
            // Toggle between original and new color
            if (isOriginalColor)
            {
                light.color = newColor;
            }
            else
            {
                light.color = originalColor;
            }

            // Flip the state
            isOriginalColor = !isOriginalColor;
        };
    }
}
