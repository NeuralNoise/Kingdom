using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Resource
{
    public enum ResourcesType { Wood, Stone, Food, Gold}
    public ResourcesType Type;
    public int Value;
}