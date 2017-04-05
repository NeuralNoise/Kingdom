using UnityEngine;

public class Selectable : MonoBehaviour, ISelectable
{
    #region Properties
    bool m_selected;
    public bool Selected
    {
        get { return m_selected; }
    }
    #endregion

    #region Public Methods
    public void Select()
    {
        if (!m_selected)
        {
            m_selected = true;
        }
    }
    public void Deselect()
    {
        if (m_selected)
        {
            m_selected = false;
        }
    }
    #endregion
}