using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLimiter : MonoBehaviour
{

    public float minRotation = -45f;
    
    public float maxRotation = 45f;


    private void LateUpdate()
    {
        // Vector3 currentRotation = transform.localRotation.eulerAngles;
        // currentRotation.z = Mathf.Clamp(currentRotation.z, minRotation, maxRotation);
        // transform.localRotation = Quaternion.Euler(currentRotation);

        

        // Vector3 rot = transform.localRotation.eulerAngles;
        // rot.z = 350;
        // transform.localRotation = Quaternion.Euler(rot);
    }

    public void Test(Vector3 vector)
    {

    }

    ///<summary>
    ///Clamps using with 360 degrees in mind
    ///</summary>
    private float DegreeClamp(float value, float min, float max)
    {
        if (value < min )
            return min;

        return 1f;
    }

}
