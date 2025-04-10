using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script used to handle movement across all objects in the game
public class Movement : MonoBehaviour
{
    //Variable for the rigibody component 
    private Rigidbody2D rigidBody;

    //Variable for acceleration and it's default float value
    [SerializeField]
    private float acceleration = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the Rigidbody2D component on the game object and assigns it to the rigidBody variable
        rigidBody = GetComponent<Rigidbody2D>();
    }

    //Function used to move objects in the game world on a 2D vector
    public void Move(Vector2 direction)
    {
        //The velocity of the object is equal to the direction of input multiplied by the value of acceleration
        rigidBody.velocity = direction * acceleration;
    }
}