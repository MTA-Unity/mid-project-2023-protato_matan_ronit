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

    private void Start()
    {
        switch (Rounds.RoundNumber)
        {
            case Easy:
                UIManager.EnemyCounter = 5;
                UIManager.Killcounter = 5;
                UIManager.EnemyWorth = 20;
                UIManager.enemyInterval = 2;
                Debug.Log("enemyInterval = " + UIManager.enemyInterval);
                break;
            case Medium:
                UIManager.EnemyCounter = 8;
                UIManager.Killcounter = 8;
                UIManager.EnemyWorth = 30;
                UIManager.enemyInterval = 1.5;
                break;
            case Hard:
                UIManager.EnemyCounter = 12;
                UIManager.Killcounter = 12;
                UIManager.EnemyWorth = 50;
                UIManager.enemyInterval = 1;
                break;
        }


        _money = 0;
        var chosen = ChosenCharacter.Chosen;
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
