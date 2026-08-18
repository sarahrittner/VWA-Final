using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class slimecontroller : MonoBehaviour
{

    private Rigidbody2D rb;
    private Transform target;
    public float speed = 3f;

    private Animator animator;

    public EnemyState enemystate;

    private float damageTimer = 0f;

    public float knockbackForce; // Adjust this value to control the knockback strength
    public float knockbackDuration; // Duration of the knockback effect

    public float afterknockbackslime; // Duration of the knockback effect

    public int maxHealth; // Maximum health of the slime
    public int currentHealth; // Current health of the slime


    public GameObject item;
    public Vector2 pos;
    public Quaternion rot;
    public float respawntimer;
    public Vector2 voidpos;
    public float height;
    public float width;
    public Vector2 startpos;



    public CapsuleCollider2D cc;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        ChangeState(EnemyState.idle);

        currentHealth = maxHealth; // Initialize current health to maximum health

    }

    

    // Update is called once per frame
    void Update()
    {

        if (enemystate != EnemyState.knockback)
        {

            if (enemystate == EnemyState.chase)
            {
                Vector2 direction = (target.position - transform.position).normalized;
                rb.linearVelocity = direction * speed;
            }



        }

        pos = transform.position;
        rot = transform.rotation; 



        
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

    private void OnCollisionStay2D(Collision2D collision)
    {
    if (collision.gameObject.CompareTag("Player"))
    {
        damageTimer += Time.deltaTime;

        if (damageTimer >= 2f)
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                player.ChangeHealth(-1);
            }

            damageTimer = 0f; // Timer zurücksetzen
        }

        collision.gameObject.GetComponent<PlayerController>().Knockback(transform, knockbackForce, knockbackDuration);
    }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
    if (collision.gameObject.CompareTag("Player"))
    {
        damageTimer = 0f; // Beim Verlassen zurücksetzen
    }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Slime collider tiggered");
        if (collision.CompareTag("Player"))
        {
  
            Debug.Log("es ist Spieler!");
            target = collision.transform;
            
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.chase);
        
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.idle);
        }

    }

    public void TakeDamage(int AttackDamage)
    {
        // Reduce the slime's health by the damage amount
        currentHealth -= AttackDamage;
        // You can implement health management here
    }

    public enum EnemyState
    {
        idle,
        chase,
        knockback
        
        
    }

    public void ChangeState(EnemyState newState)
    {
        enemystate = newState;

        switch (enemystate)
        {
            case EnemyState.idle:
                // Implement logic for idle state
                animator.SetBool("ismoving", false);
                break;

            case EnemyState.chase:
                // Implement logic for chase state
                animator.SetBool("ismoving", true);
                break;

            case EnemyState.knockback:
                // Implement logic for knockback state
                animator.SetBool("ismoving", false);
                break;
        }
    }

    public void Knockback(Transform Player, float knockbackForceplayer, float afterknockbackslime, float knockbackDurationslime)
   {
    
      ChangeState(EnemyState.knockback);


      Vector2 knockbackDirection = (transform.position - Player.position).normalized;
      rb.linearVelocity = knockbackDirection * knockbackForceplayer;

      Debug.Log("Slime is knocked back.");
      StartCoroutine(KnockbackCoroutine(afterknockbackslime, knockbackDurationslime));
   }

   IEnumerator KnockbackCoroutine(float afterknockbackslime, float knockbackDurationslime)
   {
        yield return new WaitForSeconds(afterknockbackslime);

      rb.linearVelocity = Vector2.zero;
      yield return new WaitForSeconds(knockbackDurationslime);
      ChangeState(EnemyState.chase);
   }

   void FixedUpdate()
   {
        if (currentHealth <= 0)
        {
            Die();
        }
   }

   void Die()
    {
     // Implement logic for when the slime's health reaches zero
     currentHealth = maxHealth;
     ChangeState(EnemyState.idle);   
     Instantiate(item, pos, rot);
     transform.position = voidpos;
     StartCoroutine(Spawner());
            
    }

    IEnumerator Spawner()
    {
        Wandering1 wandering1 = GetComponent<Wandering1>();
        wandering1.target = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        yield return new WaitForSeconds(respawntimer);
        rb.constraints = RigidbodyConstraints2D.None;

        float randomX = Random.Range(
            startpos.x - width / 2,
            startpos.x + width / 2);

        float randomY = Random.Range(
            startpos.y - height / 2,
            startpos.y + height / 2);

        transform.position = new Vector2(randomX, randomY);



    }

    
}

