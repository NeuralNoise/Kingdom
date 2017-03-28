using UnityEngine;

[RequireComponent(typeof(IDamageable))]
public class DamageOverTime : MonoBehaviour
{
    #region Properties
    IDamageable damageable;
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
            float clampedValue = Mathf.Max(value, 0);
            if (Application.isPlaying && !Mathf.Approximately(clampedValue, repeatRate))
            {
                CancelInvoke();
                InvokeRepeating("Damage", 0, clampedValue);
            }
            repeatRate = value;
        }
    }
    #endregion

    #region Private Methods
    void Start()
    {
        damageable = GetComponent<IDamageable>();
        InvokeRepeating("Damage", 0, RepeatRate);
    }
    void Damage()
    {
        damageable.TakeDamage(Amount);
    }
    #endregion
}