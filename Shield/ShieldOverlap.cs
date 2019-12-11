using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOverlap : MonoBehaviour
{
    public float surfaceArc = 170f;
    public bool showArc = false;

    ///<summary>
    ///Checks if given point lands within shield angle.
    ///</summary>
    public bool OverlapShield(Vector3 point)
    {
        Vector2 dir = (point - transform.position).normalized;
        if (Vector3.Angle(transform.up, dir) < surfaceArc / 2)
            return true;
        else
            return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        if (showArc)
        {
            Gizmos.DrawLine(transform.position, MyUtility.DirFromAngle(surfaceArc / 2) + transform.position);
            Gizmos.DrawLine(transform.position, MyUtility.DirFromAngle(-surfaceArc / 2) + transform.position);
        }
        
    }
}
