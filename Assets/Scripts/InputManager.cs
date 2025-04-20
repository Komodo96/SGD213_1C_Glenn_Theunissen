using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Variable for the movement script that handles the Move function
    private EngineBase movement;

    // Variable for the Weapon Base Script
    [SerializeField]
    private WeaponBase weapon;

    public WeaponBase Weapon
    {
        get
        {
            return weapon;
        }

        set
        {
            weapon = value;
        }
    }

    void Start()
    {
        // Get the Movement component and assign it to the movement variable
        movement = GetComponent<EngineBase>();

        // Assign the Weapon component to the weapon variable
        weapon = GetComponent<WeaponBase>();
    }

    void Update()
    {
        // Movement input
        float input = Input.GetAxis("Horizontal");
        movement.Move(Vector2.right * input);

        // Fire weapon if the fire button is pressed
        if (Input.GetButton("Fire1"))
        {
            if (weapon != null)
            {
                weapon.Shoot();
            }
        }
    }

    /// <summary>
    /// SwapWeapon handles creating a new WeaponBase component based on the given weaponType. 
    /// This will populate the newWeapon's controls and remove the existing weapon ready for usage.
    /// </summary>
    /// <param name="weaponType">The given weaponType to swap our current weapon to, this is an enum in WeaponBase.cs</param>
    public void SwapWeapon(WeaponType weaponType)
    {
        WeaponBase newWeapon = null;
        switch (weaponType)
        {
            case WeaponType.machineGun:
                newWeapon = gameObject.AddComponent<WeaponMachineGun>();
                break;
            case WeaponType.tripleShot:
                newWeapon = gameObject.AddComponent<WeaponTripleShot>();
                break;
        }

        // Update weapon controls (spawn point, bullet prefab)
        newWeapon.UpdateWeaponControls(weapon);

        // Dynamically set the object pool (player or enemy pool)
        if (weaponType == WeaponType.machineGun || weaponType == WeaponType.tripleShot)
        {
            newWeapon.SetObjectPool(GameObject.Find("PlayerObjectPooler").GetComponent<ObjectPooler>());
        }

        // Destroy the old weapon
        Destroy(weapon);

        // Set the new weapon
        weapon = newWeapon;
    }
}
