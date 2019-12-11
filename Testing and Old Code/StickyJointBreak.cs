using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyJointBreak : MonoBehaviour
{

    private void OnJointBreak2D(Joint2D brokenJoint)
    {
        brokenJoint.connectedBody.AddForce(-brokenJoint.reactionForce);
        Destroy(gameObject);
    }

}
