#pragma warning disable 0649    //disables SerializeField + private warning
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHoldDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject door_;
    [SerializeField]
    private SpriteRenderer buttonRend_;
    private Color startColor_;

    private void Awake()
    {
        startColor_ = buttonRend_.color;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        OpenDoor();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CloseDoor();
    }

    private void CloseDoor()
    {
        buttonRend_.color = startColor_;
        door_.SetActive(true);
    }

    private void OpenDoor()
    {
        buttonRend_.color = Color.green;
        door_.SetActive(false);
    }
}
