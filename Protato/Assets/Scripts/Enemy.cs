using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject player;
     
    public float speed;

    public int damage;

    private int _hp;

    public Character playerScript;

    private const int Easy = 3;
    private const int Medium = 2;
    private const int Hard = 1;

    [SerializeField] private GameObject deathEffect;

    private float _lastTimeHit;

    [SerializeField] private EnemyHealthBar enemyHealthBar;
      
    
    private void Start()
    {
        switch (Rounds.RoundNumber)
        {
            case Easy:
                speed = 2;
                _hp = 30;
                damage = 20;
                break;
            case Medium:
                speed = 3;
                _hp = 40;
                damage = 20;
                break;
            case Hard:
                speed = 4;
                _hp = 50;
                damage = 25;
                break;
        }
        
        
        player = GameObject.FindWithTag("Player");

        enemyHealthBar.SetSliderMax(_hp);

        playerScript = GameObject.FindWithTag("Player").GetComponent<Character>();
    }
    
    private void Update()
    {

        if (UIManager.IsPaused) return;
        
        var pTrans = player.transform.position;
        var trans = transform.position;
        
        var direction = pTrans - trans;
        direction.Normalize();
        
        transform.position =
            Vector2.MoveTowards(trans, pTrans, speed * Time.deltaTime);
    }

    private void OnHit()
    {
        _hp -= UIManager.Damage;
        enemyHealthBar.SetSlider(_hp);
        // Play vanishing animation, apply visual effect, or deactivate the enemy
        if (_hp > 0) return;
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
        var deathEffectAnimation = Instantiate(deathEffect);
        deathEffectAnimation.transform.position = transform.position;
        UIManager.Killcounter--;
        Destroy(deathEffectAnimation, 1f);
        playerScript.AddMoney(10);    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bullet":
                // Handle collision with enemy
                //destroy bullet     
                Destroy(collision.gameObject);
                this.OnHit();
                break;
            case "Player":
                playerScript.TakeDamage(damage);
                _lastTimeHit = 3;
                break;
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _lastTimeHit -= Time.deltaTime;
        if (!collision.gameObject.CompareTag("Player")) return;
        if (_lastTimeHit > 0) return;
        _lastTimeHit = 3;
        playerScript.TakeDamage(damage);
            
    }

    
}
