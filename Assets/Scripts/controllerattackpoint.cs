using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class controllerattackpoint : MonoBehaviour
{
    public PlayerController PlayerController;




    void Update()
    {
        if (PlayerController.move.y > 0)
        {
            transform.localPosition = new Vector3(0f, 0.07f, 0f);
        }
        else if (PlayerController.move.y < 0)
        {
            transform.localPosition = new Vector3(0f, -0.08f, 0f);
        }
        else if (PlayerController.move.x > 0)
        {
            transform.localPosition = new Vector3(0.1f, 0f, 0f);
        }
        else if (PlayerController.move.x < 0)
        {
            transform.localPosition = new Vector3(-0.1f, 0f, 0f);
        }


        
    }





}


