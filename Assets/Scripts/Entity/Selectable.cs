using UnityEngine;

public class Selectable : MonoBehaviour, ISelectable
{
    #region Properties
    bool m_selected;
    public bool Selected
    {
        get { return m_selected;  }
    }

    SpriteRenderer m_spriteRenderer;
    #endregion

    #region Public Methods
    public void Select()
    {
        if(!m_selected)
        {
            m_selected = true;
            m_spriteRenderer.enabled = true;
        }
    }
    public void Deselect()
    {
        if(m_selected)
        {
            m_selected = false;
            m_spriteRenderer.enabled = false;
        }
    }
    #endregion

    #region Private Methods
    void Awake()
    {
        m_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        if(m_spriteRenderer == null)
        {
            Debug.LogWarning("Selectable on " + name + " can't find the SpriteRenderer component");
        }
    }
    #endregion
}