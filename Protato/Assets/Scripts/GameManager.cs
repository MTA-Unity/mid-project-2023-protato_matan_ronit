using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public List<GameObject> variableForPrefab;

    private Camera _mainCamera;

    private GameObject _prefab;

    private int _money;
    
    public static GameObject Player;

    public static float EnemyCounter;

    private void Start()
    {
        UIManager.Money = 0;

        EnemyCounter = 0;
        
        _money = 0;
        var chosen = ChosenCharacter._chosen;
       
        Player = Instantiate(variableForPrefab[chosen], new Vector3((float)0.6187416, (float)-0.1874166, 0), Quaternion.identity);
        Player.tag = "Player";

        UIManager.Health = chosen switch
        {
            0 => 100,
            1 => 250,
            _ => UIManager.Health // Use current value if none of the cases match
        };
    }
    
    public void AddMoney(int coins)
    {
        _money += coins;
    }
    
    public bool SubMoney(int amount)
    {
        if (_money < amount) return false;
        _money -= amount;
        return true;
    }

}
