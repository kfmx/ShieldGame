#pragma warning disable 0649    //disables SerializeField + private warning
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOpenDoor : MonoBehaviour, IBashable
{
    [SerializeField]
    private GameObject door_;
    [SerializeField]
    private SpriteRenderer buttonRend_;

    public void Bashed(Transform player)
    {
        OpenDoor();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OpenDoor();
    }

    private void OpenDoor()
    {
        buttonRend_.color = Color.green;
        door_.SetActive(false);
    }
}
