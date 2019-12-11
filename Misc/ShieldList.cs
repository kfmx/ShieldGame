using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShieldList")]
public class ShieldList : ScriptableObject
{
    [System.Serializable]
    public class ShieldListEntry
    {
        public string name;
        public bool active;
        public Color color;
        public Color colorAlt;
    }

    public ShieldListEntry[] list;
}
