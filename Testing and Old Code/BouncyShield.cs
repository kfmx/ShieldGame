using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyShield : MonoBehaviour
{
    public bool bouncy = false;
    public float bounceForce = 30f;
    private ShieldOverlap shieldOverlap_;
    private Rigidbody2D rb_;

    private void Awake()
    {
        shieldOverlap_ = GetComponent<ShieldOverlap>();
        rb_ = GetComponentInParent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (bouncy && shieldOverlap_.OverlapShield(other.contacts[0].point))
        {
            rb_.AddForce(-transform.up * bounceForce, ForceMode2D.Impulse);
        }
    }

}
