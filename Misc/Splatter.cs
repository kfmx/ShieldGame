using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splatter : MonoBehaviour
{
    private Transform parent_;

    public void SetParent(Transform parent)
    {
        parent_ = parent;
    }

    private void LateUpdate()
    {
        if (!parent_.gameObject.activeSelf || parent_ == null)
        {
            Debug.Log("Splatter parent is null or inactive");
            Destroy(gameObject);
        }
    }
}