using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;


    [SerializeField] private double enemyInterval; //how long to wait before the enemies pop out 
   // private float currentEnemyInterval;


    private void Start()
    {
        //currentEnemyInterval = enemyInterval;
        enemyInterval = UIManager.enemyInterval;
        StartCoroutine(spawnEnemy(enemyInterval, enemyPrefab));
    }

    private IEnumerator spawnEnemy(double interval, GameObject enemy)
    {
        yield return new WaitForSeconds((float)interval);
        yield return new WaitUntil(() => !UIManager.IsPaused);
            if (UIManager.EnemyCounter > 0)
            {
                UIManager.EnemyCounter--;
                Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-5f, 5)),
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
                StartCoroutine(spawnEnemy(interval, enemy));
            }
            else
            {
                SceneManager.LoadScene("UserWin");
            }
    }
}
