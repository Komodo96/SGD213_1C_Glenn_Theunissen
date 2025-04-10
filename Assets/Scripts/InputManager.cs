using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //Variable for the movement script that handles the Move function
    private Movement movement;

    //Variable for the Shooting script that handles the Shoot function
    private Shooting shooting;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the Movement component assigns it to the movement variable
        movement = GetComponent<Movement>();

        //Gets the Shooting component and assigns it to the shooting variable
        shooting = GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the direction of movement on a horizontal axis based on the input and float value 
        float input = Input.GetAxis("Horizontal");

        //The float value of input is multiplied with the Vector 2 right and creates movement i.e. pressing D would make the value 1 and pressing A would make the value -1
        movement.Move(Vector2.right * input);

        //When the Fire button is pressed, call the shooting script and the shoot function
        if (Input.GetButton ("Fire1"))
        {
            shooting.Shoot();
        }
    }
}
