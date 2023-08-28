using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider enemyHealthSlider; // Reference to the UI Slider component

    public void SetSlider(float amount)
    {
        if (amount > enemyHealthSlider.maxValue || amount < enemyHealthSlider.minValue)
        {
            Debug.Log("bad value = " + amount);
            return;
        }
        enemyHealthSlider.value = amount;
    }

    public void SetSliderMax(float amount)
    {
        enemyHealthSlider.maxValue = amount;
        enemyHealthSlider.minValue = 0;
        SetSlider(amount);
    }
}