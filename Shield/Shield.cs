using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield
{
    public string name;
    public Color32 color;
    public Color32 colorAlt;
    public bool active;
    public bool thrown = false;

    public Shield(string name, bool active, Color32 color)
    {
        this.name = name;
        this.active = active;
        this.color = color;
    }
    public Shield(string name, bool active, Color32 color1, Color32 color2)
    {
        this.name = name;
        this.active = active;
        color = color1;
        colorAlt = color2;
    }
}
