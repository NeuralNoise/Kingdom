using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable, IHealable, IDisplayableByBar
{
    [SerializeField]
    private int maxHP;
    public int MaxHP
    {
        get { return maxHP; }
        set {
            maxHP = value;
            CurrentHP = Mathf.Clamp(CurrentHP, 0, value);
        }
    }

    [SerializeField]
    private int currentHP;
    public int CurrentHP
    {
        get { return currentHP; }
        private set
        {
            currentHP = Mathf.Clamp(value, 0, MaxHP);
            OnChangePercentage.Invoke((float)CurrentHP * 100 / MaxHP);
        }
    }

    [SerializeField, Candlelight.PropertyBackingField]
    private OnChangePercentageEvent m_OnChangePercentage = new OnChangePercentageEvent();
    public OnChangePercentageEvent OnChangePercentage
    {
        get
        {
            return m_OnChangePercentage;
        }
        set { m_OnChangePercentage = value; }
    }

    public void TakeDamage(int amount)
    {
        CurrentHP -= amount;
    }
    public void TakeHeal(int amount)
    {
        CurrentHP += amount;
    }
}