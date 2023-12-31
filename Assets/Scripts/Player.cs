using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHuman
{
    [SerializeField]
    private float maxHP;

    public event Action OnPlayerDeath;
    private float hp;

    private void Start()
    {
        hp = maxHP;
    }

    public float GetHealth()
    {
        return hp;
    }

    public void TakeDamage(float amount)
    {
        hp -= amount;

        if (hp <= 0)
        {
            //player death event:
            //note game manager needs to subscribe to this event to indicate game over.
            OnPlayerDeath?.Invoke();
        }
    }

    

}
