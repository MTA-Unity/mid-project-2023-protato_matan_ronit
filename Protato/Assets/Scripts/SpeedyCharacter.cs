using UnityEngine;

public class SpeedyCharacter : Character
{
    public void speedyCharacter()
    {
        CharacterName = "Speedy";
        Health = 100;
        Speed = 10;
        Power = 5;
    }
    
    private void Start()
    {
        Health = maxHealth;
        Debug.Log("healthBar: " + healthBar); // Check if the reference is null
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(Health, maxHealth);
        }
    }
}
