using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyUtility
{
    ///<summary>
    ///Checks if given layer is inside given layermask
    ///</summary>
    public static bool IsInLayerMask(int layer, LayerMask layermask)
    {
        return layermask == (layermask | (1 << layer));
    }

    ///<summary>
    ///Returns vector direction from given angle
    ///</summary>
    public static Vector3 DirFromAngle(float angleInDegrees)
    {
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
    }

}
