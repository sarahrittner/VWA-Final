using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageZone : MonoBehaviour
{
   void OnTriggerStay2D(Collider2D other)
   {
       PlayerController controller = other.GetComponent<PlayerController>();


       if (controller != null)
       {
           controller.ChangeHealth(-1);
       }
       Debug.Log("Player is in the damage zone. Current health: " + controller.health);
   }
}
