﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for causing damage when collision occurs
public class DamageOnCollision : DetectCollisionBase
{
    [SerializeField]
    private int damageToDeal;

    protected override void ProcessCollision(GameObject other)
    {
        base.ProcessCollision(other);
        if (other.GetComponent<IHealth>() != null) 
        {
            other.GetComponent<IHealth>().Damage(damageToDeal);
        } 
        else 
        {
            Debug.Log(other.name + " does not have an IHealth component");
        }

        Destroy(gameObject);
    }
}
