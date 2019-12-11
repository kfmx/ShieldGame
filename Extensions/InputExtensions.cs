using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputExtensions
{
    private static Dictionary<string, bool> axesInUse_ = new Dictionary<string, bool>();

    private static bool AxisInUse(string name)
    {
        if (!axesInUse_.ContainsKey(name))
        {
            axesInUse_.Add(name, false);
            return axesInUse_[name];
        }
        else
        {
            return axesInUse_[name];
        }
    }
    private static void AxisInUse(string name, bool setBoolean)
    {
        axesInUse_[name] = setBoolean;
    }
    public static bool AxisToButtonDown(string axisName)
    {
        if (Input.GetAxisRaw(axisName) != 0)
        {
            if (!AxisInUse(axisName))
            {
                AxisInUse(axisName, true);
                return true;
            }
        }
        else
        {
            AxisInUse(axisName, false);
        }

        return false;
    }
    ///<summary>
    ///Returns -1, 0, or 1
    ///</summary>
    public static int AxisToButtonDownInt(string axisName)
    {
        if (Input.GetAxisRaw(axisName) != 0)
        {
            if (!AxisInUse(axisName))
            {
                AxisInUse(axisName, true);
                return Mathf.CeilToInt(Input.GetAxisRaw(axisName));
            }
        }
        else
        {
            AxisInUse(axisName, false);
        }

        return 0;
    }
}