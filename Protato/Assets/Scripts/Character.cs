using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private GameObject CharacterPrfab;
    
    [SerializeField] protected string characterName{ get; set; }
    [SerializeField] protected float speed{ get; set; }
    [SerializeField] protected float power{ get; set; }
    [SerializeField] protected float fireRate{ get; set; }
    [SerializeField] protected float health { get; set; }


    private GameObject variableForPrefab;

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
       _rb = GetComponent<Rigidbody2D>();
       
       _mainCamera = Camera.main;

        
       if (ChosenCharacter._chosen == 1)
       {
           variableForPrefab = Resources.Load("prefabs/Speedy", typeof(GameObject)) as GameObject;
       }
       else
       {
           //variableForPrefab = Resources.Load("prefabs/Tanky", typeof(GameObject)) as GameObject;
       }
       
       Instantiate(variableForPrefab, new Vector3(0, 0, 0), Quaternion.identity);
       
       //_uiManager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        // if (!_uiManager.IsPaused)
        // {
        HandleMovement();
        HandleShooting();
        // }
        // else
        // {
        //     _rb.velocity = Vector2.zero;
        // }
    }

    private void HandleShooting()
    {
        if (Input.GetKeyDown("Fire1") && Time.time >= _nextFireTime)
        {
            Debug.Log("shoot");
            Shoot();
            _nextFireTime = Time.time + 0.5f;
            //_uiManager.IncreasePoints(10);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.CompareTag("Asteroid"))
        // {
        //     // Handle collision
        //     //_uiManager.DecreaseLives();
        // }
    }
    
    private void Shoot()
    {
        var fireDirection = (firePoint.position - transform.position).normalized;
        var bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(fireDirection);
        bullet.SetActive(true);
    }

    virtual protected void HandleMovement()
    {
        // Player movement
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        var moveDirection = new Vector2(horizontalInput, verticalInput).normalized;
        _rb.velocity = moveDirection * speed;
        
        var viewportPosition = _mainCamera.WorldToViewportPoint(transform.position);
        if (viewportPosition.x > 1f) viewportPosition.x = 0f;
        if (viewportPosition.x < 0f) viewportPosition.x = 1f;
        if (viewportPosition.y > 1f) viewportPosition.y = 0f;
        if (viewportPosition.y < 0f) viewportPosition.y = 1f;
        transform.position = _mainCamera.ViewportToWorldPoint(viewportPosition);
    }
    
    public void Attack()
    {
        Debug.Log(characterName + " attacks with power " + power);
    }
    
    
}



