using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script used to handle movement across all objects in the game
public class EngineBase : MonoBehaviour
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

    /// <summary>
    /// Accelerate takes a direction as a parameter, and applies a force in this provided direction
    /// to ourRigidbody, based on the acceleration variables and the delta time.
    /// </summary>
    /// <param name="horizontalInput">A direction vector, expected to be a unit vector (magnitude of 1).</param>
    //  public void Accelerate(Vector2 direction)
    //{
    //    //calculate our force to add
    //    Vector2 forceToAdd = direction * acceleration * Time.deltaTime;
    //// apply forceToAdd to ourRigidbody
    //rigidBody.AddForce(forceToAdd);
    //}
}