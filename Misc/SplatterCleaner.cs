using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatterCleaner : MonoBehaviour
{
    public static SplatterCleaner instance; 
    private GameObject[] splatterArray_;

    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void CleanSplatter()
    {
        FindSplatter();
        for (int i = 0; i < splatterArray_.Length; i++)
        {
            Destroy(splatterArray_[i]);
        }
        Debug.Log("Splatter has been cleaned up");
    }

    private void FindSplatter()
    {
        splatterArray_ = GameObject.FindGameObjectsWithTag("Splatter");
    }

}
