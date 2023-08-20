using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public List<GameObject> variableForPrefab;

    private Camera _mainCamera;

    private GameObject _prefab;

    private int _money;
    
    private static GameObject _player;

    private const int Easy = 3;
    private const int Medium = 2;
    private const int Hard = 1;

    public static float EnemyCounter;
    
    public static float EnemyDeadCounter;

    private void Start()
    {
        switch (Rounds.RoundNumber)
        {
            case Easy:
                EnemyCounter = 2;
                break;
            case Medium:
                EnemyCounter = 3;
                break;
            case Hard:
                EnemyCounter = 4;
                break;
            default:
                break;

        }
        

        _money = 0;
        var chosen = ChosenCharacter.Chosen;
        Debug.Log("GameManager UIMManager.Health = " + UIManager.Health);
        Debug.Log("GameManager UIManager.Money = " + UIManager.Money);
        _player = Instantiate(variableForPrefab[chosen], new Vector3((float)0.6187416, (float)-0.1874166, 0), Quaternion.identity);
        _player.tag = "Player";
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
