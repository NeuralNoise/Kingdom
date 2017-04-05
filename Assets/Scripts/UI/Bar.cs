using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

[ExecuteInEditMode]
public class Bar : MonoBehaviour
{
    #region Properties
    [SerializeField, Candlelight.PropertyBackingField(typeof(RangeAttribute), 0f, 100f)]
    private float m_Percentage;
    public float Percentage
    {
        get { return  m_Percentage; }
        set
        {
            m_Percentage = value;
            SetColor(value);
            SetSize(value);
        }
    }

    [SerializeField, Candlelight.PropertyBackingField]
    private Color m_FullColor;
    public Color FullColor
    {
        get { return m_FullColor; }
        set { m_FullColor = value; }
    }

    [SerializeField, Candlelight.PropertyBackingField]
    private BarStep[] m_Steps;
    public BarStep[] GetSteps()
    {
        return (BarStep[])m_Steps.Clone();
    }
    public void SetSteps(BarStep[] value)
    {
        m_Steps = (BarStep[])value.Clone();
        SetColor(m_Percentage);
    }

    [SerializeField, Candlelight.PropertyBackingField]
    private IDisplayableByBar m_IDisplayableByBar;
    public IDisplayableByBar IDisplayableByBar
    {
        get { return m_IDisplayableByBar; }
        set
        {
            if(m_IDisplayableByBar != null)
            {
                m_IDisplayableByBar.OnChangePercentage.RemoveListener(m_OnChangePercentageAction);

            }
            m_IDisplayableByBar = value;
            if(m_IDisplayableByBar != null)
            {
                m_IDisplayableByBar.OnChangePercentage.AddListener(m_OnChangePercentageAction);
            }
        }
    }

    private RectTransform m_fillerRectTransform;
    private Image m_fillerImage;
    private UnityAction<float> m_OnChangePercentageAction; 
    #endregion

    #region Private Methods
    private void Awake()
    {
        m_fillerRectTransform = transform.FindChild("Filler").GetComponent<RectTransform>();
        m_fillerImage = m_fillerRectTransform.GetComponent<Image>();
        m_OnChangePercentageAction = new UnityAction<float>((value) => OnChangePercentage(value));
    }
    private void SetColor(float value)
    {
        BarStep[] stepsSorted = m_Steps.Clone() as BarStep[];
        Array.Sort(stepsSorted);
        Color color = FullColor;
        for (int i = 0; i < stepsSorted.Length; i++)
        {
            if(value <= stepsSorted[i].Percentage)
            {
                color = stepsSorted[i].Color;
                break;
            }
        }
        m_fillerImage.color = color;
    }
    private void SetSize(float value)
    {
        m_fillerRectTransform.anchorMax = new Vector2(value / 100, m_fillerRectTransform.anchorMax.y);
    }
    private void OnChangePercentage(float value)
    {
        Percentage = value;
    }
    #endregion
}       