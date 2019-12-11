#pragma warning disable 0649    //disables SerializeField + private warning
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float cameraSpeed = 6f;

    [SerializeField]
    private Transform target_;

    private void OnEnable()
    {
        transform.position = new Vector3(target_.position.x, target_.position.y, transform.position.z);
    }

    private void LateUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        if (target_ != null)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(target_.position.x, target_.position.y, transform.position.z), Time.deltaTime * cameraSpeed);
        }
    }

}
