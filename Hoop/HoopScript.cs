#pragma warning disable 0649    //disables SerializeField + private warning
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HoopScoreScreen))]
public class HoopScript : MonoBehaviour
{

    [SerializeField]
    private Transform resetZone_;
    [SerializeField]
    private HoopScoreScreen scoreScreen_;

    private void OnTriggerEnter2D(Collider2D other)
    {
        scoreScreen_.Score();
    }

}
