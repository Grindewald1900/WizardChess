using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralTools
{
    /// <summary>
    /// Get distance between two game objects according to their x and z coordinate
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="destin"></param>
    /// <returns></returns>
    public static float GetRealDistance(Vector3 origin, Vector3 destin)
    {
        var xDistanceSqrt = Math.Pow(origin.x - destin.x, 2);
        var yDistanceSqrt = Math.Pow(origin.z - destin.z, 2);
        if (xDistanceSqrt + yDistanceSqrt == 0) return 0;
        return Convert.ToSingle(Math.Sqrt(xDistanceSqrt + yDistanceSqrt));
    }
}
