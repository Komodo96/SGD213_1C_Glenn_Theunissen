using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{

    //The game object bullet that will be fired
    [SerializeField]
    private GameObject bullet;

    //The time since the last shot fired 
    private float timer = 0f;

    //The variable that will be used to adjust how soon the player can shoot after firing a shot
    [SerializeField]
    private float delay = 1f;

    //The distance that the bullet will spawn away from the player
    private float offset = 2f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the bullet offset distance to be half of the players size + half of the bullet size
        offset = GetComponent<Renderer>().bounds.size.y / 2 + bullet.GetComponent<Renderer>().bounds.size.y / 2; 
    }

    //Function used to shoot a bullet
    public void Shoot()
    {
        //Variable for the current time in game as a float
        float currentTime = Time.time;

        // Check if the current time - the value of the timer variable is greater than the value of delay  variable
        if (currentTime - timer > delay)
        {
            //If so, get the spawn position for the bullet by using the bullet offset variable
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + offset);

            //Spawn the bullet and set it's rotation
            Instantiate(bullet, spawnPosition, transform.rotation);

            //Set the value of the timer variable to the current time so that there is a new delay for the next shot fired
            timer = currentTime;
        }
    }
}
