using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected string CharacterName{ get; set; }
    [SerializeField] protected float Speed{ get; set; }
    [SerializeField] protected float Damage{ get; set; }
    [SerializeField] protected float FireRate{ get; set; }
    [SerializeField] protected int maxHealth { get; set; }
    [SerializeField] protected int Health { get; set; }

    public HealthBar healthBar;

    public Transform firePoint;
    private float _nextFireTime;

    public GameObject bulletPrefab;
    
    private Rigidbody2D _rb;
    
    private Camera _mainCamera;

    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
       _mainCamera = Camera.main;
       Health = maxHealth;
       // Find the HealthBar GameObject by its tag
       var healthBarObject = GameObject.FindWithTag("HealthBarTag");
       healthBar = healthBarObject.GetComponent<HealthBar>();
       Debug.Log("HealthBar reference: " + healthBar);
       UIManager.Health = Health;
       if (healthBar != null)
       {
           healthBar.UpdateHealthBar(Health, maxHealth);
       }
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
        Shoot();
        _nextFireTime = Time.time + 0.5f;
    }
    
    private void Shoot()
    {
        if (!_mainCamera)
        {
           // Debug.Log("Main camera reference is missing!!");
        }
        else
        {
           // Debug.Log("Not Null!!");
            var mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition).normalized;
            var bulletDirection = (mousePosition - transform.position).normalized;
            ShootBullet(bulletDirection);
        }
    }
    
    private void ShootBullet(Vector2 direction)
    {
        var bulletObject = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        var bullet = bulletObject.GetComponent<Bullet>();
        bullet.SetDirection(direction * Bullet.moveSpeed);
        bulletObject.SetActive(true);
    }

     private void HandleMovement()
    {
        var pos = transform.position;
       
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
    
    virtual public void TakeDamage(int damageAmount)
    {
        Debug.Log("before Health = " + Health);
        Health -= damageAmount;
        Health = Mathf.Clamp(Health, 0, maxHealth);
        Debug.Log("clamp = "+Health);
        UIManager.Health = Health;
        healthBar.UpdateHealthBar(Health, maxHealth);
        Debug.Log("Health = " + Health);
        Debug.Log("UIManager.Health = " + UIManager.Health);
        if (Health <= 0)
        {
            // Handle player death or game over
        }
    }
}



