using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movable)),RequireComponent(typeof(Selectable))]
public class UniteInput : MonoBehaviour
{
    #region Properties
    Movable m_movable;
    Selectable m_selectable;
    LayerMask m_layerMask;
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    void Awake()
    {
        m_movable = GetComponent<Movable>();
        if(m_movable == null)
        {
            Debug.LogWarning("UniteInput on " + name + " can't find the Movable component");
        }
        m_selectable = GetComponent<Selectable>();
        if (m_selectable == null)
        {
            Debug.LogWarning("UniteInput on " + name + " can't find the Selectable component");
        }
        m_layerMask = 1 << LayerMask.NameToLayer("Map");
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if (m_selectable.Selected)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if(Physics.Raycast(ray, out hitInfo,200, m_layerMask))
                {
                    m_movable.Move(hitInfo.point);
                }
            }
        }
    }
    #endregion
}
