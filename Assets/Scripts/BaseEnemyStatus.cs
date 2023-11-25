using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script holds key enemy statistics like health and damage. Damage and debuffs should be done to this component.
public class BaseEnemyStatus : MonoBehaviour, IHuman
{
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float strength; // Not yet implemented
    [SerializeField]
    private float attackSpeed; // Not yet implemented

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.name == "DamageTester")
        {
            TakeDamage(1.0f);
        }
    }
}
