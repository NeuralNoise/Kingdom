using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IMovable)),RequireComponent(typeof(ISelectable))]
public class UniteInput : MonoBehaviour
{
    #region Properties
    IMovable m_movable;
    ISelectable m_selectable;
    LayerMask m_layerMask;
    #endregion

    #region Private Methods
    void Awake()
    {
        m_movable = GetComponent<IMovable>();
        m_selectable = GetComponent<ISelectable>();
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
