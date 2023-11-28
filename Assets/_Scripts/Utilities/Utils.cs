using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public static class Utils 
{
    public static List<T> GetEnumList<T>()
    {
        return ((T[])System.Enum.GetValues(typeof(T))).ToList();
    }

   
    

}
