using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Handles the Player health bar and enemy health bars
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    //The players health bar
    [SerializeField]
    private Slider sldPlayerHealth;

    //The enemies health bar
    [SerializeField]
    private Slider sldEnemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Debug.LogError("There is more than one UIManager in the scene, this will break the Singleton pattern.");
        }
        instance = this;
    }

    //Updates the player health bar
    public void UpdatePlayerHealthSlider(float percentage)
    {
        sldPlayerHealth.value = percentage;
    }

    //Updates the enemy health bar
    public void UpdateEnemyHealthSlider(float percentage)
    {
        if (sldEnemyHealth != null)
        {
            sldEnemyHealth.value = percentage;
        }
    }
}
