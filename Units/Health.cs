using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 5000;
    public float currentHealth;
    public float healthRegeneration = 3;

    public Health(int max, float regen)
    {
        maxHealth = max;
        healthRegeneration = regen;
    }


    public event Action<float> OnHealthPercentChanged = delegate { };

    
    private void Start()
    {
        currentHealth = maxHealth;
        InvokeRepeating("HealthRegeneration", 1f, 1f);
    }

    public void ModifyHealth(int amount)
    {
        currentHealth += amount;

        float currentHealthPercentage = (float)currentHealth / (float)maxHealth;
        OnHealthPercentChanged(currentHealthPercentage);
    }

    // Update is called once per frame
    void Update()
    {
        EnsureMaxHealthLimit();
    }


    private void HealthRegeneration()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += healthRegeneration;
        }
    }

    private void EnsureMaxHealthLimit()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

}
