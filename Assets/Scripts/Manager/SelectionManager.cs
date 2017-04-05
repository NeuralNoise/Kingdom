using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.Events;

public class SelectionManager : MonoBehaviour
{
    #region Properties
    [SerializeField, Candlelight.PropertyBackingField]
    private List<Selectable> m_ObjectSelected;
    public ReadOnlyCollection<Selectable> ObjectSelected
    {
        get { return new ReadOnlyCollection<Selectable>(m_ObjectSelected); }
    }
    public OnChangeSelectable OnSelect = new OnChangeSelectable();
    public OnChangeSelectable OnDeselect = new OnChangeSelectable();
    #endregion

    #region Public Methods
    public void Add(IEnumerable<Selectable> selectables)
    {
        foreach (var item in selectables) Add(item);
    }
    public void Add(Selectable selectable)
    {
        m_ObjectSelected.Add(selectable);
        selectable.Select();
        OnSelect.Invoke(selectable);
    }
    public void Remove(IEnumerable<Selectable> selectables)
    {
        foreach (var item in selectables) Remove(item);
    }
    public void Remove(Selectable selectable)
    {
        m_ObjectSelected.Remove(selectable);
        selectable.Deselect();
        OnDeselect.Invoke(selectable);
    }
    #endregion
}

[Serializable]
public class OnChangeSelectable : UnityEvent<Selectable> { }