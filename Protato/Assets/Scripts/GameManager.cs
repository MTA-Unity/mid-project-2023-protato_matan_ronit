using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;


public class GameManager : MonoBehaviour
{
    public List<GameObject> _variableForPrefab;

    private Camera _mainCamera;

    private GameObject prefab;

    private int Money;
    
    public static GameObject player;

    private void Start()
    {
        UIManager._money = 0;
        
        Money = 0;
        Debug.Log("chosen = " + ChosenCharacter._chosen);
       
        player = Instantiate(_variableForPrefab[ChosenCharacter._chosen - 1], new Vector3((float)0.6187416, (float)-0.1874166, 0), Quaternion.identity);

        UIManager._health = ChosenCharacter._chosen switch
        {
            1 => 100,
            2 => 250,
            _ => UIManager._health // Use current value if none of the cases match
        };
    }
    
    public void AddMoney(int coins)
    {
        Money += coins;
    }
    
    public bool SubMoney(int amount)
    {
        if (Money < amount) return false;
        Money -= amount;
        return true;
    }

}
