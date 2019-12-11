#pragma warning disable 0649    //disables SerializeField + private warning
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMovement : MonoBehaviour
{
    [SerializeField]
    private Transform shield_;
    private Transform point_ = null;

    public void Move(Vector2 direction)
    {
        if (direction.magnitude < 0.3f)
            return;

        float angle = Vector2.SignedAngle(Vector2.up, direction);
        shield_.eulerAngles = new Vector3(0, 0, angle);
    }

    //This method is not currently in use, used for sticky shield testing
    public void StickyMove(Vector2 direction)
    {
        if (direction.magnitude < 0.3f)
            return;
        
        if (point_ == null)
            return;

        Vector2 dir = (point_.position - transform.position).normalized;

        float angle = Vector2.SignedAngle(dir, direction);
        angle = Mathf.Clamp(angle, -70f, 70f);
        var angle360 = Vector2.SignedAngle(Vector2.up, dir);
        if (angle360 < 0)
            angle360 = 360 + angle360;

        shield_.eulerAngles = new Vector3(0, 0, angle360 + angle);
    }


    public void SetPoint(Transform transform)
    {
        point_ = transform;
    }

}
