using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;


    [SerializeField] private float enemyInterval = 0.5f; //how long to wait before the enemies pop out 
   // private float currentEnemyInterval;


    private void Start()
    {
        //currentEnemyInterval = enemyInterval;
        StartCoroutine(spawnEnemy(enemyInterval, enemyPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

            if (UIManager.EnemyCounter > 0)
            {
                UIManager.EnemyCounter--;
                var newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-5f, 5)),
                    Quaternion.identity);
            }
            else
            {
                if (UIManager.Killcounter <= 0)
                {
                    Rounds.RoundNumber--;
                    SceneManager.LoadScene("Store");
                }
            }
        if (Rounds.RoundNumber > 0) 
        {
            enemyInterval += 3.0f;
            StartCoroutine(spawnEnemy(interval, enemy));
        }
        else
        {
            SceneManager.LoadScene("UserWin");
        }  
    }
}
