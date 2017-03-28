using UnityEngine;

[RequireComponent(typeof(IHealable))]
public class HealOverTime : MonoBehaviour
{
    #region Properties
    IHealable healable;
    [SerializeField]
    private int amount;
    public int Amount
    {
        get { return amount; }
        set { amount = Mathf.Max(value,0); }
    }
    [SerializeField]
    private float repeatRate;
    public float RepeatRate
    {
        get { return repeatRate; }
        set
        {
            float clampedValue = Mathf.Max(value,0);
            if (Application.isPlaying && !Mathf.Approximately(clampedValue,repeatRate))
            {
                CancelInvoke();
                InvokeRepeating("Heal", 0, clampedValue);
            }
            repeatRate = value;
        }
    }
    #endregion

    #region Private Methods
    void Start()
    {
        healable = GetComponent<IHealable>();
        InvokeRepeating("Heal", 0, RepeatRate);
    }
    void Heal()
    {
        healable.TakeHeal(Amount);
    }
    #endregion
}
