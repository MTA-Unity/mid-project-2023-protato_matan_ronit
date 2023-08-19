using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected string characterName;
    [SerializeField] protected double speed;
    [SerializeField] protected double damage;
    [SerializeField] protected float fireRate;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int health;

    public HealthBar healthBar;

    public Transform firePoint;
    private float _nextFireTime;

    public GameObject bulletPrefab;
    
    protected Rigidbody2D Rb;
    
    protected Camera MainCamera;

    protected Character()
    {
        maxHealth = UIManager.MaxHealth;
        health = UIManager.MaxHealth;
        speed = UIManager.Speed;
        damage = UIManager.Damage;
        
        Debug.Log("Character UIMManager.Health = " + UIManager.Health);
        Debug.Log("Character UIManager.Money = " + UIManager.Money);
    }

    private void Awake()
    {
        health = UIManager.MaxHealth;
    }

    protected virtual void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        MainCamera = Camera.main; 
    }

    
    protected virtual void Update()
    {
        
    }

    protected virtual void HandleShooting()
    {
        if (!Input.GetButton("Fire1") || Time.time < _nextFireTime) return;
        Shoot();
        _nextFireTime = Time.time + 0.5f;
    }
    
    private void Shoot()
    {
        if (!MainCamera)
        {
           Debug.Log("Main camera reference is missing!!");
        }
        else
        {
           // Debug.Log("Not Null!!");
            var mousePosition = MainCamera.ScreenToWorldPoint(Input.mousePosition);
            var bulletDirection = (mousePosition - transform.position).normalized;
            ShootBullet(bulletDirection);
        }
    }
    
    private void ShootBullet(Vector2 direction)
    {
        var bulletObject = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        var bullet = bulletObject.GetComponent<Bullet>();
        bullet.SetDirection(direction * Bullet.MoveSpeed);
        bulletObject.SetActive(true);
    }

    
    
    public void TakeDamage(int damageAmount)
    {
        Debug.Log("before Health = " + health);
        UIManager.Health -= damageAmount;
        UIManager.Health = Mathf.Clamp(UIManager.Health, 0, UIManager.MaxHealth);
        health = UIManager.Health;
        
        healthBar.SetSlider(health);
        Debug.Log("Health = " + health);
        Debug.Log("UIManager.Health = " + UIManager.Health);
        if (health <= 0)
        {
            Debug.Log("user lost");
            SceneManager.LoadScene("UserLost");
            // Handle player death or game over
        }
    }

    public void AddMoney(int money)
    {
        UIManager.Money += money;
    }
}



