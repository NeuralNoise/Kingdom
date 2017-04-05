using System;
using UnityEngine;
using Candlelight;

[Serializable]
public struct BarStep : IPropertyBackingFieldCompatible<BarStep> , IComparable
{
    [SerializeField, PropertyBackingField]
    private Color m_Color;
    public Color Color
    {
        get { return m_Color; }
        set { m_Color = value; }
    }

    [SerializeField, PropertyBackingField(typeof(RangeAttribute), 0f, 100f)]
    private float m_Percentage;
    public float Percentage
    {
        get { return m_Percentage; }
        set { m_Percentage = value; }
    }

    public BarStep(Color color,float percentage) : this()
    {
        m_Color = color;
        m_Percentage = percentage;
    }
    object ICloneable.Clone()
    {
        return this;
    }
    public override bool Equals(object obj)
    {
        return (obj == null || !(obj is BarStep)) ? false : Equals((BarStep)obj);
    }
    public bool Equals(BarStep other)
    {
        return m_Color == other.m_Color && string.Equals(Percentage, other.Percentage);
    }
    public override int GetHashCode()
    {
        return ObjectX.GenerateHashCode(m_Color.GetHashCode(), m_Percentage.GetHashCode());
    }
    public int CompareTo(object obj)
    {
        if(obj is BarStep)
        {
            BarStep barStep = (BarStep) obj;
            return (int)(Percentage - barStep.Percentage);
        }
        else
        {
            throw new ArgumentException(); 
        }
    }
    int IPropertyBackingFieldCompatible.GetSerializedPropertiesHash()
    {
        return GetHashCode();
    }
}
