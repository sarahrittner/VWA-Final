using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Slime : MonoBehaviour
{
   void OnTriggerStay2D(Collider2D other)
   {
       PlayerController controller = other.GetComponent<PlayerController>();


       if (controller != null)
       {
           controller.ChangeHealth(-1);
       }
       Debug.Log("Player gets hit by slime. Current health: " + controller.health);
   }
}
