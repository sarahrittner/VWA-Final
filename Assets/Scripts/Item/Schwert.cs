using UnityEngine;

public class Schwert : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

         if (controller != null)
         {
            controller.hatSchwert = true;
            Destroy(gameObject);
            Debug.Log("Player collected Schwert");
         }
    }
}
