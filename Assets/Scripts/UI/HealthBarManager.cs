using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    #region Properties
    public GameObject m_HealthBarPrefab;
    Dictionary<Health,Bar> m_HealthBars = new Dictionary<Health, Bar>();
    #endregion

    #region Public Methods
    public void Display(Health health)
    {
        if(!m_HealthBars.ContainsKey(health))
        {
            GameObject healthBarGameObject = Instantiate(m_HealthBarPrefab, transform);
            Bar bar = healthBarGameObject.GetComponent<Bar>();
            bar.Percentage = health.CurrentHP * 100.0f / health.MaxHP;
            healthBarGameObject.SetActive(true);
            bar.IDisplayableByBar = health;
            m_HealthBars.Add(health, bar);
        }
    }
    public void Hide(Health health)
    {
        if(m_HealthBars.ContainsKey(health))
        {
            Destroy(m_HealthBars[health].gameObject);
            m_HealthBars.Remove(health);
        }
    }
    #endregion

    #region Methods
    public void Start()
    {
        SelectionManager selectionManager = FindObjectOfType<SelectionManager>();
        selectionManager.OnSelect.AddListener((target) => OnSelect(target));
        selectionManager.OnDeselect.AddListener((target) => OnDeselect(target));
    }
    private void Update()
    {
        foreach (var item in m_HealthBars) item.Value.transform.position = Camera.main.WorldToScreenPoint(item.Key.transform.position + 2.3f * Vector3.up);
    }
    private void OnSelect(Selectable selectable)
    {
        Health health = selectable.GetComponent<Health>();
        if (health) Display(health);
    }
    private void OnDeselect(Selectable selectable)
    {
        Health health = selectable.GetComponent<Health>();
        if (health) Hide(health);
    }
    #endregion

}
