using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
  // Variables related to player character movement
  public InputAction MoveAction;
  public InputAction MoveActionwasd;
  Rigidbody2D rigidbody2d;
  Vector2 move;
   public float speed = 3.0f;

   private Animator animator;

   public Transform AttackPoint;
   public float AttackRange;
   public LayerMask EnemyLayers;
   public int AttackDamage;
  

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
      move = MoveActionwasd.ReadValue<Vector2>();
      if (move == Vector2.zero)
      {
         move += MoveAction.ReadValue<Vector2>();
      }



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

   }




// FixedUpdate has the same call rate as the physics system
  void FixedUpdate()
  {
     
     
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
      animator.SetTrigger("Attack");

      Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);

      foreach (Collider2D enemy in hitEnemies)
      {
         Debug.Log("Du schlägst " + enemy.name);
         Slime slime = enemy.GetComponent<Slime>();
         if (slime != null)
         {
            slime.TakeDamage(AttackDamage);
         }
      }
  
   }

   void OnDrawGizmosSelected()
   {
      if (AttackPoint == null)
         return;

      Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
   }
}
