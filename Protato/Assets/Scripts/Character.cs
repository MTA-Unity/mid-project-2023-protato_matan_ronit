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

    private AudioSource _audioShoot;
    
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
    }

    private void Awake()
    {
        health = UIManager.MaxHealth;
    }

    protected virtual void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        MainCamera = Camera.main;
        _audioShoot = GetComponent<AudioSource>();
    }

    
    protected virtual void Update()
    {
        
    }

    protected virtual void HandleShooting()
    {
        if (!Input.GetButton("Fire1") || Time.time < _nextFireTime) return;
        _audioShoot.Play();
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
        UIManager.Health -= damageAmount;
        UIManager.Health = Mathf.Clamp(UIManager.Health, 0, UIManager.MaxHealth);
        health = UIManager.Health;
        
        healthBar.SetSlider(health);
        if (health <= 0)
        {
            SceneManager.LoadScene("UserLost");
        }
    }

    public void AddMoney(int money)
    {
        UIManager.Money += money;
    }
}



