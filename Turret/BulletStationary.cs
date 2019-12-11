using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStationary : MonoBehaviour, IBashable
{
    private Rigidbody2D rb_;
    private float lifetime_ = 5f;

    private void Awake()
    {
        rb_ = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb_.velocity.magnitude > 50)
            Destroy(gameObject);

        if (lifetime_ > 0)
            lifetime_ -= Time.deltaTime;
        else
            Destroy(gameObject);
    }

    public void Bashed(Transform player)
    {
        gameObject.layer = LayerMask.NameToLayer("PlayerBullet");

        rb_.velocity = Vector3.zero;
        var dir = (transform.position - player.position).normalized;
        rb_.AddForce(dir * 40, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        DeathAnim();
        Destroy(gameObject);
    }

    private void DeathAnim()
    {
        //Death animation
    }

}
