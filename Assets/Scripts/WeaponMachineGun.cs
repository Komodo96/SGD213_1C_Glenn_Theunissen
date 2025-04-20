using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The basic single shot machine gun used by the player by default and basic enemies
public class WeaponMachineGun : WeaponBase
{
    public override void Shoot()
    {
        float currentTime = Time.time;

        // Only fire if enough time has passed since the last shot
        if (currentTime - lastFiredTime > fireDelay)
        {
            // Ensure the object pool is assigned
            if (objectPool == null)
            {
                Debug.LogWarning("Object pool is not assigned for MachineGun!");
                return;  // Exit if no object pool is assigned
            }

            // Determine if this is the player or enemy shooting
            bool isPlayerShooting = IsPlayerShooting();

            // Get a bullet from the correct object pool (based on whether the shooter is a player or enemy)
            GameObject newBullet = objectPool.GetObjectFromPool(isPlayerShooting);  // true for player bullets, false for enemy bullets

            if (newBullet != null)
            {
                newBullet.SetActive(true);
                newBullet.transform.position = bulletSpawnPoint.position;

                // Set the bullet's movement direction (upward for player, downward for enemy)
                newBullet.GetComponent<MoveConstantly>().Direction = isPlayerShooting ? Vector2.up : Vector2.down;

                // Update the last fired time
                lastFiredTime = currentTime;
            }
            else
            {
                Debug.LogWarning("Failed to get a bullet from the object pool!");
            }
        }
    }

    // Determines if the shooter is the player
    private bool IsPlayerShooting()
    {
        return gameObject.CompareTag("Player");
    }
}