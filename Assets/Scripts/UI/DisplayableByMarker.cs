using UnityEngine;

public class DisplayableByMarker : MonoBehaviour, IDisplayableByMarker
{
    [SerializeField, Candlelight.PropertyBackingField]
    private Sprite m_Marker;
    public Sprite Marker
    {
        get { return m_Marker; }
        set { m_Marker = value; }
    }
}
