using UnityEngine;

public class SpeedyCharacter : Character
{
    protected override void Start()
    {
        base.Start();
        
        characterName = "Speedy";
        
        // Find the HealthBar GameObject by its tag
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetSliderMax(UIManager.MaxHealth);
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
        Debug.Log("moving "+ speed);
        speed = UIManager.Speed;
        var pos = transform.position;
       
        if (Input.GetKey("w"))
        {
            pos.y += (float)(speed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            pos.x += (float)(speed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            pos.y -= (float)(speed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            pos.x -= (float)(speed * Time.deltaTime);
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
