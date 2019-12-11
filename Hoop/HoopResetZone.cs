#pragma warning disable 0649    //disables SerializeField + private warning
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HoopScoreScreen))]
public class HoopResetZone : MonoBehaviour, IBashable
{
    [SerializeField]
    private HoopScoreScreen scoreScreen_;

    public void Bashed(Transform player)
    {
        scoreScreen_.ResetScore();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        scoreScreen_.ResetScore();
    }
}
