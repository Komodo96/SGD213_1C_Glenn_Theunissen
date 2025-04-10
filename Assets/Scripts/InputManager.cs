using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //Variable for the movement script that handles the Move function
    private EngineBase movement;

    //Variable for the Shooting script that handles the Shoot function
    private Shooting shooting;

    //Variable for the Weapon Base Script
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

    // Start is called before the first frame update
    void Start()
    {
        //Gets the Movement component assigns it to the movement variable
        movement = GetComponent<EngineBase>();

        //Gets the Shooting component and assigns it to the shooting variable
        shooting = GetComponent<Shooting>();

        weapon = GetComponent<WeaponBase>();
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
            if (weapon != null)
            { 
                shooting.Shoot();
            }
        }
    }

    /// <summary>
    /// SwapWeapon handles creating a new WeaponBase component based on the given weaponType. This
    /// will popluate the newWeapon's controls and remove the existing weapon ready for usage.
    /// </summary>
    /// <param name="weaponType">The given weaponType to swap our current weapon to, this is an enum in WeaponBase.cs</param>
    public void SwapWeapon(WeaponType weaponType)
    {
        // make a new weapon dependent on the weaponType
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

        // update the data of our newWeapon with that of our current weapon
        newWeapon.UpdateWeaponControls(weapon);
        // remove the old weapon
        Destroy(weapon);
        // set our current weapon to be the newWeapon
        weapon = newWeapon;
    }
}
