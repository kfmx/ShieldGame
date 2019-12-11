using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : MonoBehaviour
{

    public int shieldIndex = 1;
    private ShieldManager shieldManager_;

    private void Start()
    {
        shieldManager_ = GameObject.FindGameObjectWithTag("Player").GetComponent<ShieldManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shieldManager_.ActivateShield(shieldIndex, true);
            shieldManager_.GoToShield(shieldIndex);
            Destroy(gameObject);
        }
    }

}
