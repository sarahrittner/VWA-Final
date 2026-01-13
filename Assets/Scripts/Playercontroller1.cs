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
  



  // Variables related to the health system
  public int maxHealth = 5;
  int currentHealth;
  public int health { get { return currentHealth; }}


  // Variables related to temporary invincibility
  public float timeInvincible = 2.0f;
  bool isInvincible;
  float damageCooldown;



  // Start is called before the first frame update
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
     move = MoveAction.ReadValue<Vector2>();
      if (move == Vector2.zero)
      {
         move = MoveActionwasd.ReadValue<Vector2>();
      }


     

     if (isInvincible)
       {
           damageCooldown -= Time.deltaTime;
           if (damageCooldown < 0)
               isInvincible = false;
       }

      if (Input.GetKeyDown(KeyCode.Space))
      {
         animator.SetTrigger("Attack");
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
            return;

         isInvincible = true;
         damageCooldown = timeInvincible;
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
}
