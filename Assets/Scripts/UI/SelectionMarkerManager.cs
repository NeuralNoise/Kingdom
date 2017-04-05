using System.Collections.Generic;
using UnityEngine;

public class SelectionMarkerManager : MonoBehaviour
{
    #region Properties
    public GameObject m_SelectionMarkerPrefab;
    Dictionary<DisplayableByMarker, Marker> m_SelectionMarkers = new Dictionary<DisplayableByMarker, Marker>();
    #endregion

    #region Public Methods
    public void Display(DisplayableByMarker displayableByMarker)
    {
        if (!m_SelectionMarkers.ContainsKey(displayableByMarker))
        {
            GameObject selectionMarkerGameObject = Instantiate(m_SelectionMarkerPrefab, transform);
            Marker selectionMarker = selectionMarkerGameObject.GetComponent<Marker>();
            selectionMarker.DisplayableByMarker = displayableByMarker;
            m_SelectionMarkers.Add(displayableByMarker, selectionMarker);
        }
    }
    public void Hide(DisplayableByMarker displaybleByMarker)
    {
        if (m_SelectionMarkers.ContainsKey(displaybleByMarker))
        {
            Destroy(m_SelectionMarkers[displaybleByMarker].gameObject);
            m_SelectionMarkers.Remove(displaybleByMarker);
        }
    }
    #endregion

    #region Methods
    private void Start()
    {
        SelectionManager selectionManager = FindObjectOfType<SelectionManager>();
        selectionManager.OnSelect.AddListener((target) => OnSelect(target));
        selectionManager.OnDeselect.AddListener((target) => OnDeselect(target));
    }
    private void OnSelect(Selectable selectable)
    {
        DisplayableByMarker displayableByMarker = selectable.GetComponent<DisplayableByMarker>();
        if (displayableByMarker) Display(displayableByMarker);
    }
    private void OnDeselect(Selectable selectable)
    {
        DisplayableByMarker displayableByMarker = selectable.GetComponent<DisplayableByMarker>();
        if (displayableByMarker) Hide(displayableByMarker);
    }
    #endregion

}
