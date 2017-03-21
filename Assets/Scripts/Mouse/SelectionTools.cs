using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class SelectionTools : MonoBehaviour
{
    #region Properties
    public GameObject m_selectionPrefab;
    public float m_raycastMaxDistance = 100.0f;

    RectTransform m_rectTransform;
    LayerMask m_layerMask;
    RTSCamera m_RTSCamera;
    List<Selectable> m_uniteSelected = new List<Selectable>();
    bool m_waitingForSecondClick;
    #endregion

    #region Private Methods
    #region Unity
    void Awake()
    {
        m_rectTransform = GetComponent<RectTransform>();
        m_RTSCamera = FindObjectOfType<RTSCamera>();
        m_layerMask = 1 << LayerMask.NameToLayer("Selectable");
    }
    void Update()
    {
        if (Input.GetButtonDown("Select"))
        {
            if(!m_waitingForSecondClick)
            {
                StartCoroutine(c_WaitForSecondClick());
                StartCoroutine(SelectBySimpleClick());
            }
            else
            {
                SelectByDoubleClick();
                m_waitingForSecondClick = false;
            }
        }
    }
    #endregion
    #region Selection
    IEnumerator SelectBySimpleClick()
    {
        m_RTSCamera.RotationLocked = true;
        m_RTSCamera.DisplacementLocked = true;

        GameObject selectionTools = Instantiate(m_selectionPrefab, transform);
        RectTransform rectTransform = selectionTools.GetComponent<RectTransform>();
        Vector2 localStartPosition, localCurrentPosition, deltaPosition, anchoredPosition, sizeDelta;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(m_rectTransform, Input.mousePosition, null , out localStartPosition);
        while (Input.GetButton("Select"))
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(m_rectTransform, Input.mousePosition, null , out localCurrentPosition);
            deltaPosition = localCurrentPosition - localStartPosition;
            if (deltaPosition.x > 0)
            {
                anchoredPosition.x = localStartPosition.x;
                sizeDelta.x = deltaPosition.x;
            }
            else
            {
                anchoredPosition.x = localCurrentPosition.x;
                sizeDelta.x = -deltaPosition.x;
            }
            if (deltaPosition.y > 0)
            {
                anchoredPosition.y = localStartPosition.y;
                sizeDelta.y = deltaPosition.y;
            }
            else
            {
                anchoredPosition.y = localCurrentPosition.y;
                sizeDelta.y = -deltaPosition.y;
            }
            rectTransform.anchoredPosition = anchoredPosition;
            rectTransform.sizeDelta = sizeDelta;
            yield return true;
        }
        IEnumerable<Selectable> selectables = GetSelectables(rectTransform).ToArray();
        Selectable[] unites = (from selectable in selectables where selectable.GetComponent<Unite>() != null select selectable).ToArray();
        Selectable[] buildings = (from selectable in selectables where selectable.GetComponent<Building>() != null select selectable).ToArray();
        if(unites.Length == 0)
        {
            if(buildings.Length != 0)
            {
                Select(new Selectable[] { buildings[0] });
            }
            else
            {
                Select(new Selectable[0] { });
            }
        }
        else
        {
            Select(unites);
        }
        Destroy(selectionTools);
        m_RTSCamera.RotationLocked = false;
        m_RTSCamera.DisplacementLocked = false;
    }
    void SelectByDoubleClick()
    {
        IEnumerable<Selectable> selectables = GetSelectables(m_rectTransform);
        IEnumerable<Selectable> itemsToSelect = new List<Selectable>();
        Selectable selectable = CastRay(Input.mousePosition);
        if(selectable)
        {
            Unite unite = CastRay(Input.mousePosition).GetComponent<Unite>();
            Building building = CastRay(Input.mousePosition).GetComponent<Building>();
            if (unite)
            {
                itemsToSelect = from item in selectables where (item.GetComponent<Unite>() != null && item.GetComponent<Unite>().Type == unite.Type) select item;
            }
            else if(building)
            {
                itemsToSelect = from item in selectables where (item.GetComponent<Building>() != null && item.GetComponent<Building>().Type == building.Type) select item;
            }
        }
        Select(itemsToSelect.ToArray());
    }
    #endregion
    #region Selection Tools
    IEnumerable<Selectable> GetSelectables(RectTransform rectTransform)
    {
        List<Selectable> selectables = new List<Selectable>();
        for (int x = 0; x < rectTransform.rect.width; x += 10)
        {
            for (int y = 0; y < rectTransform.rect.height; y += 10)
            {
                selectables.AddIfNotNullAndUnique(CastRay(rectTransform.position + new Vector3(x, y, 0)));
            }
        }
        selectables.AddIfNotNullAndUnique(CastRay(rectTransform.position + (Vector3)rectTransform.rect.size));
        return selectables;
    }
    Selectable CastRay(Vector2 rayPosition)
    {
        Selectable selectable = null;
        RaycastHit hitInfo;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(rayPosition), out hitInfo, m_raycastMaxDistance, m_layerMask))
        {
            selectable = hitInfo.collider.GetComponent<Selectable>();
        }
        return selectable;
    }
    void Select(Selectable[] selectables)
    {
        IEnumerable<Selectable> itemsToDeselect = from item in m_uniteSelected where !selectables.Contains(item) select item;
        foreach (var item in itemsToDeselect) item.Deselect();
        m_uniteSelected.RemoveAll((item) => itemsToDeselect.Contains(item));

        IEnumerable<Selectable> itemsToSelect = from item in selectables where !m_uniteSelected.Contains(item) select item;
        foreach (var item in itemsToSelect)
        {
            m_uniteSelected.Add(item);
            item.Select();
        }
    }
    IEnumerator c_WaitForSecondClick()
    {
        m_waitingForSecondClick = true;
        yield return new WaitForSeconds(0.2f);
        m_waitingForSecondClick = false;
    }
    #endregion
    #endregion
}