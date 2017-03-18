using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtension
{
    public static bool AddIfNotNullAndUnique<T>(this List<T> collection, T item)
    {
        if(item != null && !collection.Contains(item))
        {
            collection.Add(item);
            return true;
        }
        else
        {
            return false;
        }
    }
}