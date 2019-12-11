#pragma warning disable 0649    //disables SerializeField + private warning
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyShield : MonoBehaviour
{
    public bool sticky = false;
    private ShieldOverlap shieldOverlap_;
    private Rigidbody2D rb_;
    [SerializeField]
    private FixedJoint2D stickyJointPrefab_;
    public FixedJoint2D joint;
    [SerializeField]
    private ShieldMovement shieldMovement_;

    private void Awake()
    {
        shieldOverlap_ = GetComponent<ShieldOverlap>();
        rb_ = GetComponentInParent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (sticky && shieldOverlap_.OverlapShield(other.contacts[0].point))
        {
            joint = Instantiate(stickyJointPrefab_, other.contacts[0].point, Quaternion.identity);
            joint.connectedBody = rb_;
            shieldMovement_.SetPoint(joint.transform);
        }
    }
}
