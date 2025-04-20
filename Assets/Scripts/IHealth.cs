using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// IHealth defines how to speak to any Health component
/// </summary>
public interface IHealth
{
    // get the amount of health this health component currently has
    int CurrentHealth { get; }
    // get the maximum health of this health component
    int MaxHealth { get; }

    /// <summary>
    /// TakeDamage handles the functionality for taking damage
    /// </summary>
    /// <param name="damageAmount">The amount of damage to lose, this value should be positive</param>
    void TakeDamage(int damageAmount);

    /// <summary>
    /// Heal handles the functionality of receiving health
    /// </summary>
    /// <param name="healingAmount">The amount of health to gain, this value should be positive</param>
    void Heal(int healingAmount);

    /// <summary>
    /// Handles all functionality related to when health reaches or goes below zero, should perform all necessary cleanup.
    /// </summary>
    void Die();
}
