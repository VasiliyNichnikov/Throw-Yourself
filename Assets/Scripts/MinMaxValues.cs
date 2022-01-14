using System;
using UnityEngine;

[Serializable]
public class MinMaxValues
{
    public float MinClamp01
    {
        get
        {
            if (Min != 0)
                return Min / 100f;
            return 0;
        }
    }

    public float MaxClamp01
    {
        get
        {
            if (Max != 0)
            {
                return Max / 100f;
            }

            return 0;
        }
    }

    public float Min;
    public float Max;
}