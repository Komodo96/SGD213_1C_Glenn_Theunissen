using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Pickup allows the player to change to the triple shot weapon when collided with and tells the player object what weapon to use 
public class Pickup : MonoBehaviour
{
    [SerializeField]
    private WeaponType weaponType;

    //When the player collides with the pickup...
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject player = col.gameObject;
            HandlePlayerPickup(player);
        }
    }

    /// <summary>
    /// HandlePlayerPickup handles all of the actions after a player has been collided with.
    /// It grabs the Weapon component from the player, transfers all information to a
    /// new Weapon (based on the provided weaponType).
    /// </summary>
    /// <param name="player"></param>
    private void HandlePlayerPickup(GameObject player)
    {
        // get the playerInput from the player
        InputManager playerInput = player.GetComponent<InputManager>();
        // If the player doesn't have a player input then return
        if (playerInput == null)
        {
            Debug.LogError("Player doesn't have a PlayerInput component.");
            return;
        }
        else
        {
            // tell the playerInput to SwapWeapon based on our weaponType
            playerInput.SwapWeapon(weaponType);
        }
    }

}

public enum WeaponType { machineGun, tripleShot }
