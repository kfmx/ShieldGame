#pragma warning disable 0649    //disables SerializeField + private warning
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimitBox : MonoBehaviour
{
    [Range(0, 200)]
    public float boxX = 10;
    [Range(0, 200)]
    public float boxY = 10;
    public bool showLimitBox = true;
    [SerializeField]
    private Camera cameraToLimit_;
    private Transform cameraTransform_;

    private void Start()
    {
        if (GetCameraWorldWidth() > boxX || GetCameraWorldHeight() > boxY)
            Debug.LogError("camera can't be contained");
    }

    private void LateUpdate()
    {
        LimitCamera();
    }

    private float GetCameraWorldHeight()
    {
        return cameraToLimit_.orthographicSize * 2f;
    }

    private float GetCameraWorldWidth()
    {
        return cameraToLimit_.aspect * GetCameraWorldHeight();
    }

    private void LimitCamera()
    {
        cameraTransform_ = cameraToLimit_.transform;
    
        //Viewport space is normalized and relative to the camera. The bottom-left of the viewport is (0,0); the top-right is (1,1)
        Vector3 cameraRight = cameraToLimit_.ViewportToWorldPoint(new Vector3(1, 0.5f, 0));
        Vector3 cameraLeft = cameraToLimit_.ViewportToWorldPoint(new Vector3(0, 0.5f, 0));
        Vector3 cameraTop = cameraToLimit_.ViewportToWorldPoint(new Vector3(0.5f, 1, 0));
        Vector3 cameraBottom = cameraToLimit_.ViewportToWorldPoint(new Vector3(0.5f, 0, 0));

        float limitRight = transform.position.x + boxX/2f;
        float limitLeft = transform.position.x - boxX/2f;
        float limitTop = transform.position.y + boxY/2f;
        float limitBottom = transform.position.y - boxY/2f;
        
        if (cameraRight.x > limitRight)
        {
            var temp = cameraTransform_.position;
            temp.x = limitRight - GetCameraWorldWidth()/2f;
            cameraTransform_.position = temp;
        }
        if (cameraLeft.x < limitLeft)
        {
            var temp = cameraTransform_.position;
            temp.x = limitLeft + GetCameraWorldWidth()/2f;
            cameraTransform_.position = temp;
        }
        if (cameraTop.y > limitTop)
        {
            var temp = cameraTransform_.position;
            temp.y = limitTop - GetCameraWorldHeight()/2f;
            cameraTransform_.position = temp;
        }
        if (cameraBottom.y < limitBottom)
        {
            var temp = cameraTransform_.position;
            temp.y = limitBottom + GetCameraWorldHeight()/2f;
            cameraTransform_.position = temp;
        }
        
    }

    private void OnDrawGizmos()
    {
        if (showLimitBox)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, new Vector3(boxX, boxY, 1));
        }
    }
}
