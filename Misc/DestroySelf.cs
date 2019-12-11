using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float lifetime = 1f;

    private void Update()
    {
        if (lifetime > 0)
            lifetime -= Time.deltaTime;
        else
            Destroy(gameObject);
    }
}
