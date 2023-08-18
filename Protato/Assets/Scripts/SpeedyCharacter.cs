using UnityEngine;

public class SpeedyCharacter : Character
{
    private void speedyCharacter()
    {
        CharacterName = "Speedy";
        maxHealth = 150;
        Speed = 5;
        Damage = 5;
    }
    
    private void Start()
    {
        speedyCharacter();
    }
}
