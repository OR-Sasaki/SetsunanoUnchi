using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public static class CommonUtil
{
    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}