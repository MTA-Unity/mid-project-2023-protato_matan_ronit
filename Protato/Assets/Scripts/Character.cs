using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected string characterName;
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
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
        maxHealth = 100;
        health = maxHealth;
        speed = 2;
        damage = 5;
    }

    private void Awake()
    {
        health = maxHealth;
    }

    protected virtual void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
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
        bullet.SetDirection(direction * Bullet.moveSpeed);
        bulletObject.SetActive(true);
    }

    
    
    public void TakeDamage(int damageAmount)
    {
        Debug.Log("before Health = " + health);
        health -= damageAmount;
        health = Mathf.Clamp(health, 0, maxHealth);
        UIManager.Health = health;
        
        healthBar.SetSlider(health);
        Debug.Log("Health = " + health);
        Debug.Log("UIManager.Health = " + UIManager.Health);
        if (health <= 0)
        {
            // Handle player death or game over
        }
    }
}



