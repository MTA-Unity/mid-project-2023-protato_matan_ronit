using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static float MoveSpeed = 4f;
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
    }

    private void Update()
    {
        if(!UIManager.IsPaused)
            transform.position += (Vector3)_direction * (Time.deltaTime * MoveSpeed);
    }


    public void SetDirection(Vector2 position)
    {
        _direction = position;
    }

    private void OnDestroy()
    {
        gameObject.SetActive(false);
    }
}
