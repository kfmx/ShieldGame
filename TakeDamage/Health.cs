using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TakeDamageAnimations))]
public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    private int curHealth_;
    private TakeDamageAnimations damageAnims_;

    private void Awake() 
    {
        curHealth_ = maxHealth;
        damageAnims_ = GetComponent<TakeDamageAnimations>();
    }

    public void TakeDamage(int damage)
    {
        curHealth_--;
        damageAnims_.TakeDamage();
        if (curHealth_ <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " has died.");
        //Death animation function here
        Destroy(gameObject);
    }
}
