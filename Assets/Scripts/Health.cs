using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Needed for Slider UI element

//Script used to handle the health of enemies and the player
public class Health : MonoBehaviour, IHealth
{
    [SerializeField]
    protected int currentHealth;
    public int CurrentHealth 
    { 
        get 
        {
            return currentHealth; 
        } 
    }

    [SerializeField]
    protected int maxHealth;
    public int MaxHealth 
    {
        get 
        { 
            return maxHealth; 
        } 
    }

    // Reference to the health slider for this specific enemy
    [SerializeField] private Slider healthSlider;

    // Reference to the UIManager (for player health)
    private UIManager uiManager;

    void Start()
    {
        currentHealth = maxHealth;

        // If it's the player, reference the UIManager
        if (gameObject.CompareTag("Player"))
        {
            uiManager = UIManager.instance;
        }

        // Initialize the health bar (for both the player and enemies)
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    // Heal the player by a certain amount but not above Max Health
    public void Heal(int healingAmount)
    {
        currentHealth += healingAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        // Update the health bar UI
        UpdateHealthBar();
    }

    // Function for when a player or enemy takes damage
    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // Update the health bar UI
        UpdateHealthBar();

        // If health goes below or equals 0, call Destroy Character method
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            DestroyCharacter();
        }
    }

    // Update the health bar (specific to player or enemy)
    private void UpdateHealthBar()
    {
        if (gameObject.CompareTag("Player") && uiManager != null)
        {
            // Update the player's health bar via the UIManager
            uiManager.UpdatePlayerHealthSlider((float)currentHealth / (float)maxHealth);
        }
        else if (healthSlider != null)
        {
            // Update the enemy's health bar directly
            healthSlider.value = currentHealth;
        }
    }

    // Handle the death of the enemy/player
    public void DestroyCharacter()
    {
        Destroy(gameObject);
    }
}
