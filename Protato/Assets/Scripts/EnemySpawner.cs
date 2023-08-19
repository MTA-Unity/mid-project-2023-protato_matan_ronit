using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (GameManager.EnemyCounter > 0)
        {
            Debug.Log("GameManager.EnemyCounter = " + GameManager.EnemyCounter);
            GameManager.EnemyCounter--;
            var newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-5f, 5)),
                Quaternion.identity);
        }
        else
        {
            Debug.Log("loading store");
            SceneManager.LoadScene("Store");
        }

        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
