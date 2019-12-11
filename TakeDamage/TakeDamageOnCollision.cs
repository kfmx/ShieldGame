using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class TakeDamageOnCollision : MonoBehaviour
{
    public LayerMask damageMask;
    private ShieldOverlap shieldOverlap_;
    private Health health_;

    private void Awake()
    {
        if (GetComponentInChildren<ShieldOverlap>() != null)
            shieldOverlap_ = GetComponentInChildren<ShieldOverlap>();
        health_ = GetComponent<Health>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (MyUtility.IsInLayerMask(other.gameObject.layer, damageMask))
        {
            //Is this the player? Then take shield into consideration
            if (shieldOverlap_ != null)
            {
                if (!shieldOverlap_.OverlapShield(other.contacts[0].point))
                {
                    health_.TakeDamage(1);
                }
            }
            //Not the player
            else
            {
                health_.TakeDamage(1);
            }
        }
    }
}
