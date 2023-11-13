using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script holds key enemy statistics like health and damage. Damage and debuffs should be done to this component.
public class BaseEnemyStatus : MonoBehaviour
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

    public float TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth > 0)
        {
            return currentHealth;
        }
        else
        {
            // If game starts crashing randomly after the enemy dies sometimes, it might be these two lines lol
            Invoke(nameof(Die), 0);
            return 0;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public float GetCurrentHealth()
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
