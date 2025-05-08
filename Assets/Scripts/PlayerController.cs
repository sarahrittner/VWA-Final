using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public InputAction MoveAction;
    public InputAction MoveActionwasd;

    Rigidbody2D rigidbody2d;
    
    /// <summary>
    /// This function is called when the script instance is being loaded.
    /// It is used to initialize the input actions for the player controller.
    /// </summary>
    void Start()
    {

        /// <summary>
        /// Initialize the input actions for the player controller.
        MoveAction.Enable();

        MoveActionwasd.Enable();

        rigidbody2d = GetComponent<Rigidbody2D>();

    }

    /// <summary>
    /// This function is called once per frame.
    /// It is used to update the position of the player based on input from the keyboard.
    /// </summary>
    void Update()
    {
        
        /// <summary>
        /// movement in units per second
        Vector2 move = MoveAction.ReadValue<Vector2>();
        Debug.Log("Move: " + move);
        Vector2 position = (Vector2)transform.position + move * 3.0f * Time.deltaTime;
        transform.position = position;

        ///<summary>
        /// same as above but using arrow keys
        Vector2 moveWASD = MoveActionwasd.ReadValue<Vector2>();
        Debug.Log("MoveWASD: " + moveWASD); 
        Vector2 positionWASD = (Vector2)transform.position + moveWASD * 3.0f * Time.deltaTime;
        transform.position = positionWASD;


        Vector2 move1;
        move1 = MoveAction.ReadValue<Vector2>();
        Debug.Log("Move1: " + move1);


    }

    void FixedUpdate()
    {
        

    }



}
