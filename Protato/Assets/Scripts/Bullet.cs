using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static float moveSpeed = 4f;
    public float lifeTime = 2f;
    private Camera _mainCamera;
    
    private float _startTime;
    private Rigidbody2D _rb;
    
    private Vector2 _direction;

   
    private void Awake()
    {
        Destroy(gameObject, lifeTime);
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;

       // _rb.velocity = transform.forward * moveSpeed;//
    }

    private void Update()
    {
        if(!UIManager.IsPaused)
            transform.position += (Vector3)_direction * (Time.deltaTime * moveSpeed);
    }


    public void SetDirection(Vector2 position)
    {
        _direction = position;
    }

    private void OnDestroy()
    {
        gameObject.SetActive(false);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //   // Debug.Log("Collision with tag: " + collision.gameObject.tag);
    //    if (collision.gameObject.CompareTag("Bullet") && collision.otherCollider.CompareTag("Enemy"))
    //    {
    //        Debug.Log("Collision.");
    //        // Handle collision with enemy
    //        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
    //        if (enemy != null)
    //        {
    //            //  enemy.OnHit();
    //        }

    //        // Deactivate the bullet
    //        gameObject.SetActive(false);
    //    }
    //}
}
