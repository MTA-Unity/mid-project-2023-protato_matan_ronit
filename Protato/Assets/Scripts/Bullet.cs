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
        Debug.Log("awake");
        
        Destroy(gameObject, lifeTime);
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
    }

    private void Update()
    {
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
}
