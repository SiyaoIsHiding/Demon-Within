using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagingHitbox : MonoBehaviour
{
    [SerializeField]
    private float damageAmount;

    private void OnTriggerEnter(Collider other)
    {
        Player damagedPlayer = other.gameObject.GetComponent<Player>();
        if (damagedPlayer)
        {
            damagedPlayer.TakeDamage(damageAmount);
        }
    }
}
