using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth;
    public static int currentHealth;
    private Health health;
    private void Start()
    {
        // get components
        health = GetComponent<Health>();

        // set values
        currentHealth = maxHealth;
        health.maxHealth = maxHealth;
    }

}
