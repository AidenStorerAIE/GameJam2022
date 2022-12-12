using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [System.NonSerialized]
    public float currentHealth;
    [System.NonSerialized]
    public float maxHealth;

    public ValueDisplay healthbar; //healthbar
    public bool showAtFull = false;
    
    [System.NonSerialized]
    public bool isDead = false;

    void Start()
    {
        if (healthbar == null)
            healthbar = GetComponentInChildren<ValueDisplay>();

        currentHealth = maxHealth;
        UpdateUI();
    }
    private void Update()
    {
        if (healthbar)
        {
            if (!showAtFull && currentHealth == maxHealth)
                healthbar.gameObject.SetActive(false);
            else
                healthbar.gameObject.SetActive(true);
        }

    }    
    public void Heal(int heal)
    {
        if (currentHealth < maxHealth && !isDead)
        {
            currentHealth += heal;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            UpdateUI();
        }
    }
    public void TakeDamage(float damage)
    {
        if (!isDead)
        {  
            // damage is done            
            currentHealth -= (damage);

            //health is capped
            if (currentHealth < 0)
                currentHealth = 0;

            // dies
            if (currentHealth == 0)
            {
                isDead = true;
                OnDeath();
                return;
            }           
            UpdateUI();
        }
    }
    void UpdateUI()
    {
        if (healthbar)
        {
            healthbar.SetMaxValue(maxHealth);
            healthbar.SetValue(currentHealth);
        }
    }
    void OnDeath()
    {
       
    }

    public void SetHealth(int health)
    {
        maxHealth = health;
        currentHealth = health;
        UpdateUI();
    }
}
