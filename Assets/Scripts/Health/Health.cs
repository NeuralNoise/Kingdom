using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour, IDamageable, IHealable
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
        private set { currentHP = Mathf.Clamp(value, 0, MaxHP); }
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