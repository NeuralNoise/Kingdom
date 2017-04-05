using UnityEngine;
using UnityEngine.UI;

public class Marker : MonoBehaviour
{
    #region Properties
    RectTransform m_rectTransform;

    [SerializeField, Candlelight.PropertyBackingField]
    private DisplayableByMarker m_DisplayableByMarker;
    public DisplayableByMarker DisplayableByMarker
    {
        get
        {
            return m_DisplayableByMarker;
        }
        set
        {
            m_DisplayableByMarker = value;
            Image image = GetComponent<Image>();
            image.sprite = m_DisplayableByMarker.Marker;
            image.SetNativeSize();
        }
    }
    #endregion

    #region Private Methods
    private void LateUpdate()
    {
        (transform as RectTransform).position = DisplayableByMarker.transform.position;
    }
    #endregion
}
