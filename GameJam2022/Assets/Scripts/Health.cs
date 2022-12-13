using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;

    public ValueDisplay healthbar; //healthbar
    public bool showAtFull = false;

    public StatSettings stats;
    public float healthSliderValue;

    public RespawnManager respawnManager;

    [Header("Effects")]
    public GameObject hitEffect;
    public GameObject deathEffect;

    [System.NonSerialized]
    public bool isDead = false;

    void Start()
    {
        if (healthbar == null)
            healthbar = GetComponentInChildren<ValueDisplay>();
        respawnManager = FindObjectOfType<RespawnManager>();
        currentHealth = maxHealth;
        healthSliderValue = currentHealth;
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
        if (transform.position.y < -5)
        {
            OnDeath();
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
            if(stats)
                stats.sliderH.value -= (damage);
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
                UpdateUI();

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
        if (gameObject.tag == "Enemy")
        {
            if (deathEffect)
            {
                GameObject newEffect = Instantiate(deathEffect, transform.position, hitEffect.transform.rotation);
                Destroy(newEffect, 2f);
            }
            Destroy(gameObject);
        }
        else if(gameObject.tag == "Player")
        {
            transform.position = respawnManager.spawnsPoints[respawnManager.spawnsPoints.Count - 1].transform.position;
            currentHealth = maxHealth;
            isDead = false;
        }
    }

    public void SetHealth(float health)
    {
        maxHealth = health;
        currentHealth = health;
        UpdateUI();
    }
}
