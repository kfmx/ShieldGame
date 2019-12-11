using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownShieldMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    private Vector3 direction_;
    private bool canMove_ = true;

    private void Awake()
    {
        direction_ = transform.up;
    }

    private void FixedUpdate()
    {
        if (canMove_)
            transform.position += direction_ * Time.deltaTime * movementSpeed;
    }

    public void Stop()
    {
        canMove_ = false;
        gameObject.SetActive(false);
    }
}
