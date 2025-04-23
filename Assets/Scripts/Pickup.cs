using UnityEngine;

//Script for handling both the triple shot weapon pickup and the health pickup
public class Pickup : MonoBehaviour
{
    //Variable for the type of pickup
    [SerializeField] 
    private PickupType pickupType;

    //Variable for the type of weapon 
    [SerializeField] 
    private WeaponType weaponType;

    //The amount healed by the health pickup
    [SerializeField] 
    private int healAmount = 20;

    //Called when the payer collides with the pickup
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            switch (pickupType)
            {
                case PickupType.Weapon:
                    HandleWeaponPickup(col.gameObject);
                    break;

                case PickupType.Health:
                    HandleHealthPickup(col.gameObject);
                    break;
            }
            //Then remove the pickup from the game world
            Destroy(gameObject);
        }
    }

    //Used when the player collides with a weapon pickup to swap to the triple shot
    private void HandleWeaponPickup(GameObject player)
    {
        InputManager playerInput = player.GetComponent<InputManager>();
        if (playerInput != null)
        {
            playerInput.SwapWeapon(weaponType);
        }
        else
        {
            Debug.LogWarning("Player does not have an InputManager!");
        }
    }

    //Used when the player collides with a health pickup to heal the player
    private void HandleHealthPickup(GameObject player)
    {
        IHealth playerHealth = player.GetComponent<IHealth>();
        if (playerHealth != null)
        {
            playerHealth.Heal(healAmount);
            Debug.Log($"Healed player for {healAmount} HP.");
        }
        else
        {
            Debug.LogWarning("Player does not have an IHealth component!");
        }
    }
}

public enum PickupType { Weapon, Health }
public enum WeaponType { machineGun, tripleShot }
