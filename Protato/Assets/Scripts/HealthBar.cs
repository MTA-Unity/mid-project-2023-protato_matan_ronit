using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; // Reference to the UI Slider component

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        healthSlider.maxValue = maxHealth; // Update the health slider's maximum value
        healthSlider.value = currentHealth; // Update the health slider's value
    }
}
