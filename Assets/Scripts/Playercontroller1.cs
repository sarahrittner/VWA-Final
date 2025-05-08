using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Playercontroller : MonoBehaviour
{
  // Variables related to player character movement
  public InputAction MoveAction;
  public InputAction MoveActionwasd;
  Rigidbody2D rigidbody2d;
  Vector2 move;


  // Start is called before the first frame update
  void Start()
  {
     MoveAction.Enable();

     MoveActionwasd.Enable();
    
     rigidbody2d = GetComponent<Rigidbody2D>();
  }
 
  // Update is called once per frame
  void Update()
  {
     move = MoveActionwasd.ReadValue<Vector2>();     
     move = MoveAction.ReadValue<Vector2>();

     Debug.Log(move);

  }


  void FixedUpdate()
  {
     Vector2 position = (Vector2)rigidbody2d.position + move * 3.0f * Time.deltaTime;
     rigidbody2d.MovePosition(position);


  }
}