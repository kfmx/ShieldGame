#pragma warning disable 0649    //disables SerializeField + private warning
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour, IBashable
{
    public float addedForceOnBash = 15f;
    [Range(1, 5)]
    public int bounciness = 1;
    private int prevBounciness;
    private Collider2D col_;

    private void Awake()
    {
        col_ = GetComponent<Collider2D>();
        col_.sharedMaterial = (PhysicsMaterial2D)Resources.Load("PhysicsMaterial/Bouncy" + bounciness.ToString());
        prevBounciness = bounciness;
    }

    private void Update()
    {
        if (prevBounciness != bounciness)
        {
            col_.sharedMaterial = (PhysicsMaterial2D)Resources.Load("PhysicsMaterial/Bouncy" + bounciness.ToString());
            prevBounciness = bounciness;
        }
    }

    public void Bashed(Transform player)
    {
        player.GetComponent<ShieldBash>().bashForceIn += addedForceOnBash;
    }
}
