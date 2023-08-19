using UnityEngine;

public class SpeedyCharacter : Character
{
    protected override void Start()
    {
        base.Start();
        characterName = "Speedy";
        maxHealth = 150;
        health = maxHealth;
        speed = 5;
        damage = 3;
        MainCamera = Camera.main; 
        // Find the HealthBar GameObject by its tag
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetSliderMax(maxHealth);
        Debug.Log("maxHealth = " + maxHealth);
    }
    
    protected override void Update()
    {
        base.Update();
        if (!UIManager.IsPaused)
        {
            UIManager.Health = health;
            HandleMovement();
            HandleShooting();
        }
        else
        {
            Rb.velocity = Vector2.zero;
        }
    }
    
    private void HandleMovement()
    {
        Debug.Log("moving "+ this.speed);

        var pos = transform.position;
       
        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
            //Debug.Log("w");
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
            //Debug.Log("d");
        }
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
            //Debug.Log("s");
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
            //Debug.Log("a");
        }
        
        transform.position = pos;

        if (!MainCamera)
        {
            Debug.Log("Main camera reference is missing!!");
            return;
        }

        var viewportPosition = MainCamera.WorldToViewportPoint(transform.position);
        
        if (viewportPosition.x > 1f) viewportPosition.x = 1f;
        if (viewportPosition.x < 0f) viewportPosition.x = 0f;
        if (viewportPosition.y > 1f) viewportPosition.y = 1f;
        if (viewportPosition.y < 0f) viewportPosition.y = 0f;

        transform.position = MainCamera.ViewportToWorldPoint(viewportPosition);
    }
}
