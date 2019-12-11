using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownShieldCollision : MonoBehaviour
{
    private ShieldOverlap shieldOverlap_;
    private ThrownShieldSplatter shieldSplatter_;
    private ThrownShieldMovement shieldMovement_;
    private void Awake()
    {
        shieldOverlap_ = GetComponent<ShieldOverlap>();
        shieldSplatter_ = GetComponent<ThrownShieldSplatter>();
        shieldMovement_ = GetComponent<ThrownShieldMovement>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Only splatter if collide with static rigidbodies
        if (other.rigidbody == null || other.rigidbody.bodyType == RigidbodyType2D.Static)
        {
            shieldSplatter_.Splatter();
            shieldMovement_.Stop();
        }
    }

}
