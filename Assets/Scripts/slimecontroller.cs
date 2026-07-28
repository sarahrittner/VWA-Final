using UnityEngine;

public class slimecontroller : MonoBehaviour
{

    private Rigidbody2D rb;
    private Transform target;
    public float speed = 3f;
    private bool ischasing;
    private Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (ischasing == true)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
        }
        
    }

        private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            // Implement logic for when the slime collides with the player
            // For example, you can call a method on the player to reduce health
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ChangeHealth(-1); // Example: Reduce player's health by 1
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (target == null)
            {
                target = collision.transform;
            }
            ischasing = true;
        
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ischasing = false;
            rb.linearVelocity = Vector2.zero;
        }

    }

    public void TakeDamage(int damage)
    {
        // Reduce the slime's health by the damage amount
        // You can implement health management here
    }

    public enum EnemyState
    {
        idle,
        chase
        
        
    }

    
}

