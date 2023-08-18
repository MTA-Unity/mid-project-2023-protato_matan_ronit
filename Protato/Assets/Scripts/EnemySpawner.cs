using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefeb;


    [SerializeField] private float enemyInterval = 3.5f;

    [SerializeField] private float counter;
    

    private void Start()
    {
        StartCoroutine(spawnEnemy(enemyInterval, enemyPrefeb));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        if (counter < 3)
        {
            var newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-5f, 5)),
                Quaternion.identity);
            //newEnemy.tag = "enemy";
            newEnemy.tag = "Enemy";
        }
        
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
