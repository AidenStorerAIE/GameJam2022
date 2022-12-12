using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth;
    public static int currentHealth;
    private Health health;
    public static Player Instance;
    public float healthSliderValue;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    private void Start()
    {
        
        // get components
        health = GetComponent<Health>();

        // set values
        currentHealth = maxHealth;
        health.maxHealth = healthSliderValue;
    }

}
