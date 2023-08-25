using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider enemyHealthSlider; // Reference to the UI Slider component

    public void SetSlider(float amount)
    {
        enemyHealthSlider.value = amount;
    }

    public void SetSliderMax(float amount)
    {
        enemyHealthSlider.maxValue = amount;
        SetSlider(amount);
    }
}