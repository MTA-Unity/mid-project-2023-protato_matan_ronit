using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;


    [SerializeField] private float enemyInterval = 3.5f;


    private void Start()
    {
        StartCoroutine(spawnEnemy(enemyInterval, enemyPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        if (GameManager.EnemyCounter < 3)
        {
            var newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-5f, 5)),
                Quaternion.identity);
            GameManager.EnemyCounter++;
        }
        
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
