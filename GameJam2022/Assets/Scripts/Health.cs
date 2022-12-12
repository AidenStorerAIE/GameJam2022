using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public ValueDisplay healthbar; //healthbar
    public bool showAtFull = false;

    public GameObject hitEffect;

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
            if (hitEffect)
            {
                GameObject newEffect = Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                Destroy(newEffect, 2f);
            }
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
    public void UpdateUI()
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
