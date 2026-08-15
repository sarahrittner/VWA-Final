using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class PlayerController : MonoBehaviour
{
  // Variables related to player character movement
  public InputAction MoveAction;
  public InputAction MoveActionwasd;
  Rigidbody2D rigidbody2d;
  public Vector2 move;
   public float speed = 3.0f;

   private Animator animator;

   public Transform AttackPoint;
   public float AttackRange;
   public LayerMask EnemyLayers;
   public int AttackDamage;

   private bool isKnockedback;

   public float knockbackForceplayer; // Adjust this value to control the knockback strength
   public float knockbackDurationslime; // Duration of the knockback effect

    public CapsuleCollider2D cc;


    public slimecontroller slime;

    public PolygonCollider2D skCollider2D;
    public BoxCollider2D bxCollider2D;

  

  // Variables related to the health system
  public int maxHealth;
  public int currentHealth;



  // Variables related to temporary invincibility
  public float TimeInvincible;
  bool isInvincible;
  float damageCooldown;




  // Start is called before the first frame update
  //Bewegung ist an, Leben sind voll
  void Start()
  {
     MoveAction.Enable();
     MoveActionwasd.Enable();
     rigidbody2d = GetComponent<Rigidbody2D>();

      currentHealth = maxHealth;

      animator = GetComponent<Animator>();
  }
 
  // Update is called once per frame
  void Update()
  {




     if (isInvincible)
       {
           damageCooldown -= Time.deltaTime;
           if (damageCooldown < 0)
            {  
               isInvincible = false;
            }
       }



      if (Input.GetKeyDown(KeyCode.Space))
      {
         Attack();
      }

      if (Input.GetKeyDown(KeyCode.E))
      {
         Interact();
      }

   }




// FixedUpdate has the same call rate as the physics system
  void FixedUpdate()
  {

      if (isKnockedback == false)
      {
         move = MoveActionwasd.ReadValue<Vector2>();

         if (move == Vector2.zero)
         {
         move += MoveAction.ReadValue<Vector2>();
         }
   
         Vector2 position = (Vector2)rigidbody2d.position + move * speed * Time.deltaTime;
         rigidbody2d.MovePosition(position);

         if (move != Vector2.zero)
         {
            animator.SetFloat("movex", move.x);
            animator.SetFloat("movey", move.y);
            animator.SetBool("isMoving", true);

         }
         else
         {
            animator.SetBool("isMoving", false);
         }

      }
       
  }


   public void ChangeHealth(int amount)
   {
      if (amount < 0)
      {
         if (isInvincible)
         {
          return;
         }

         
         isInvincible = true;
         damageCooldown = TimeInvincible;         
         

      }


      currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
      Debug.Log("Player health changed. Current health: " + currentHealth);

      if (currentHealth <= 0)
      {
         Die();
      }

   }

   public void Die()
   {
         Debug.Log("Player has died.");
         SceneManager.LoadScene("dead");
   }


   void Attack()
   {
      // Play attack animation  
      animator.SetBool("isAttacking", true);


    Collider2D[] colliders = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange);

    if (System.Array.Exists(colliders, collider => collider == cc))
    {
        Debug.Log("Der Collider ist innerhalb des Kreises!");
        slimecontroller slime = cc.GetComponent<slimecontroller>();
        slime.TakeDamage(AttackDamage);
        slime.Knockback(transform, knockbackForceplayer, slime.afterknockbackslime, knockbackDurationslime);
    }
  
   }

   public void Attackend()
   {
      animator.SetBool("isAttacking", false);
   }

   void OnDrawGizmosSelected()
   {
      if (AttackPoint == null)
         return;

      Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
   }


   public void Knockback(Transform enemy, float knockbackForce, float knockbackDuration)
   {
      isKnockedback = true;

      Vector2 knockbackDirection = (transform.position - enemy.position).normalized;
      rigidbody2d.linearVelocity = knockbackDirection * knockbackForce;

      Debug.Log("Player is knocked back.");
      StartCoroutine(KnockbackCoroutine(knockbackDuration));
   }

   IEnumerator KnockbackCoroutine(float knockbackDuration)
   {
      yield return new WaitForSeconds(knockbackDuration);
      isKnockedback = false;
   }


   void Interact()
   {
    Collider2D[] colliders = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange);

    Debug.Log("Interacting with objects in range.");

    foreach (Collider2D collider2D in colliders)
    {
        Glocke glocke = collider2D.GetComponent<Glocke>();
        if (glocke != null)
        {
            glocke.Interactg();
            return; // Exit after interacting with the first Glocke found
        }

        Shopkeeper shopkeeper = collider2D.GetComponent<Shopkeeper>();
        if (collider2D == skCollider2D)
         {
            shopkeeper.Interacts();
         }

       Chest chest = collider2D.GetComponent<Chest>();
       if (collider2D == bxCollider2D)
         chest.Interactc();
    }
   
   }
}
