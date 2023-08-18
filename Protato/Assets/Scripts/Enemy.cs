using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject player;
     
    public float speed;

    private float distance;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        
        distance = Vector2.Distance(transform.position, player.transform.position);
        var direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        transform.position =
            Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
