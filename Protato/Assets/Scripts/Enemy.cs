using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject player;
     
    public float speed;

    private float distance;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    //public void OnHit()
    //{
    //    // Play vanishing animation, apply visual effect, or deactivate the enemy
    //    gameObject.SetActive(false);
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Collision with tag: " + collision.gameObject.tag);
    //    if (collision.gameObject.CompareTag("Bullet"))
    //    {
    //        Debug.Log("Collision.");
    //        // Handle collision with enemy
    //        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
    //        if (enemy != null)
    //        {
    //            enemy.OnHit();
    //        }

    //        // Deactivate the bullet
    //        gameObject.SetActive(false);
    //    }
    //}

    private void Update()
    {
        
        distance = Vector2.Distance(transform.position, player.transform.position);
        var direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        transform.position =
            Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
