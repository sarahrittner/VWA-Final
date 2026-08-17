using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cave : MonoBehaviour
{

   void OnTriggerStay2D(Collider2D other)
   {
       PlayerController controller = other.GetComponent<PlayerController>();


       if (controller != null)
       {
           SceneManager.LoadScene("End");
       }

   }
}
