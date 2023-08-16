using UnityEngine;

public class Character : MonoBehaviour
{
    
    
    [SerializeField] protected string CharacterName{ get; set; }
    [SerializeField] protected float Speed{ get; set; }
    [SerializeField] protected float Power{ get; set; }
    [SerializeField] protected float FireRate{ get; set; }
    [SerializeField] protected int maxHealth { get; set; }
    [SerializeField] protected int Health { get; set; }

    public HealthBar healthBar;

    public Transform firePoint;
    private float _nextFireTime;

    public Vector2 targetPosition; // You need to set this in your game logic
    public GameObject bulletPrefab;
    
    //private UIManager _uiManager;
    private Rigidbody2D _rb;
    
    private Camera _mainCamera;

    public GameObject player;
    
    private void Start()
    {
        Speed = 10; //later change it to the specific character's speed
        _rb = GetComponent<Rigidbody2D>();
       _mainCamera = Camera.main;
       Health = maxHealth;
       // Find the HealthBar GameObject by its tag
       var healthBarObject = GameObject.FindWithTag("HealthBarTag");
       healthBar = healthBarObject?.GetComponent<HealthBar>();
       Debug.Log("HealthBar reference: " + healthBar);
       if (healthBar != null)
       {
           healthBar.UpdateHealthBar(Health, maxHealth);
       }
       //_uiManager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        // if (!_uiManager.IsPaused)
        // {
        if (_mainCamera == null)
        {
            _rb = GetComponent<Rigidbody2D>();
            _mainCamera = Camera.main;
        }

        if (!UIManager.IsPaused)
        {
            HandleMovement();
            HandleShooting();
        }
        // }
        // else
        // {
        //     _rb.velocity = Vector2.zero;
        // }
    }

    private void HandleShooting()
    {
        if (!Input.GetButton("Fire1") || Time.time < _nextFireTime) return;
        Debug.Log("shoot");
        Shoot();
        _nextFireTime = Time.time + 0.5f;
        //_uiManager.IncreasePoints(10);    
    }
    
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     // if (collision.gameObject.CompareTag("Asteroid"))
    //     // {
    //     //     // Handle collision
    //     //     //_uiManager.DecreaseLives();
    //     // }
    // }
    
    private void Shoot()
    {
        if (_mainCamera == null)
        {
           // Debug.Log("Main camera reference is missing!!");
        }
        else
        {
           // Debug.Log("Not Null!!");
            Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 bulletDirection = (mousePosition - transform.position).normalized;
            ShootBullet(bulletDirection);
        }
    }
    
    void ShootBullet(Vector2 direction)
    {
        GameObject bulletObject = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.SetDirection(direction * Bullet.moveSpeed);
        bulletObject.SetActive(true);
    }

    virtual protected void HandleMovement()
    {
        Vector3 pos = transform.position;
       
        if (Input.GetKey("w"))
        {
            pos.y += Speed * Time.deltaTime;
           // Debug.Log("w");
        }
        if (Input.GetKey("d"))
        {
            pos.x += Speed * Time.deltaTime;
            //Debug.Log("d");
        }
        if (Input.GetKey("s"))
        {
            pos.y -= Speed * Time.deltaTime;
           // Debug.Log("s");
        }
        if (Input.GetKey("a"))
        {
            pos.x -= Speed * Time.deltaTime;
          //  Debug.Log("a");
        }
        
        transform.position = pos;

        if (_mainCamera == null)
        {
            Debug.Log("Main camera reference is missing!!");
            return;
        }

        var viewportPosition = _mainCamera.WorldToViewportPoint(transform.position);
        
        if (viewportPosition.x > 1f) viewportPosition.x = 1f;
        if (viewportPosition.x < 0f) viewportPosition.x = 0f;
        if (viewportPosition.y > 1f) viewportPosition.y = 1f;
        if (viewportPosition.y < 0f) viewportPosition.y = 0f;

        transform.position = _mainCamera.ViewportToWorldPoint(viewportPosition);
    }
    
    public void Attack()
    {
        Debug.Log(CharacterName + " attacks with power " + Power);
    }
    
    public void TakeDamage(int damageAmount)
    {
        Health -= damageAmount;
        Health = Mathf.Clamp(Health, 0, maxHealth); // Clamp health to valid range
        healthBar.UpdateHealthBar(Health, maxHealth);
        
        if (Health <= 0)
        {
            // Handle player death or game over
        }
    }
}



