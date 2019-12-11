#pragma warning disable 0649    //disables SerializeField + private warning
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToughButton : MonoBehaviour, IBashable
{
    [SerializeField]
    private GameObject door_;
    [SerializeField]
    private SpriteRenderer buttonRend_;
    [SerializeField]
    private SpriteRenderer stripeRend_;

    public void Bashed(Transform player)
    {
        OpenDoor();
    }

    private void OpenDoor()
    {
        buttonRend_.color = Color.green;
        stripeRend_.color = Color.green;
        door_.SetActive(false);
    }
}
