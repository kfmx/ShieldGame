using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IBashable
{
    public float bashedForce = 40f;
    private Rigidbody2D rb_;

    private void Awake()
    {
        rb_ = GetComponent<Rigidbody2D>();
    }

    public void Bashed(Transform player)
    {
        var dir = (transform.position - player.position).normalized;
        rb_.AddForce(dir * bashedForce, ForceMode2D.Impulse);
    }

}
