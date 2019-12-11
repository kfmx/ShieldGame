using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCopyColor : MonoBehaviour
{
    //bad script, revise / remove later
    private ParticleSystem ps_;

    private void Awake()
    {
        ps_ = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        var shieldRend = GameObject.FindGameObjectWithTag("Shield").GetComponent<SpriteRenderer>();
        var main = ps_.main;
        main.startColor = shieldRend.color;        
    }
}
