using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject player;
     
    public float speed;

    public int damage;

    public Character playerScript;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        damage = 10;

        playerScript = GameObject.FindWithTag("Player").GetComponent<Character>();
    }

    private void OnHit()
    {
        // Play vanishing animation, apply visual effect, or deactivate the enemy
        Destroy(gameObject);
        GameManager.EnemyCounter--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bullet":
                Debug.Log("Collision.");
                // Handle collision with enemy
                //destroy bullet     
                Destroy(collision.gameObject);
                this.OnHit();
                break;
            case "Player":
                Debug.Log("Collision with player.");
                playerScript.TakeDamage(damage);
                break;
        }
        
    }

    private void Update()
    {
        var pTrans = player.transform.position;
        var trans = transform.position;
        
        var direction = pTrans - trans;
        direction.Normalize();
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        transform.position =
            Vector2.MoveTowards(trans, pTrans, speed * Time.deltaTime);
        
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
