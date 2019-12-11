using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 30f;
    public float jumpStrength = 100f;

    private Rigidbody2D rb_;

    private void Awake()
    {
        rb_ = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 movement)
    {
        movement *= moveSpeed;
        rb_.AddForce(new Vector2(movement.x, movement.y), ForceMode2D.Impulse);
    }

    public void Jump()
    {
        rb_.AddForce(Vector2.up * jumpStrength * 10, ForceMode2D.Impulse);
    }

    public Vector2 GetVelocity()
    {
        return rb_.velocity;
    }

    public void SetYVelocity(float y)
    {
        rb_.velocity = new Vector2(rb_.velocity.x, y);
    }
}
