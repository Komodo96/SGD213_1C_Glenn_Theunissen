using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    //Variable for the movement script that handles the Move function
    private Movement movement;

    //Variable for the direction of movement the object will take, this value is editable in the editor thanks to Serialize Field
    [SerializeField]
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the Movement component assigns it to the movement variable
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Set a direction that the object will move in
        movement.Move(direction);
    }
}
