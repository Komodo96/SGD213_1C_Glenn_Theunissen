using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private Slider sldPlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null) {
            Debug.LogError("There is more than one UIManager in the scene, this will break the Singleton pattern.");
        }
        instance = this;
    }

    public void UpdatePlayerHealthSlider(float percentage) {
        sldPlayerHealth.value = percentage;
    }
}
