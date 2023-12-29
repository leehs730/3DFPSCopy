using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public interface IDamageable
{
    void TakePhysicalDamage(int damageAmount);
}

[System.Serializable]
public class Condition
{
    [HideInInspector]
    public float curValue;
    public float maxValue;
    public float startValue;
    public float regenRate;
    public float decayRate;
    public Image uiBar;

    public void Add(float amount)
    {
        curValue = Mathf.Min(curValue + amount, maxValue);
    }

    public void Subtrack(float amount)
    {
        curValue = Mathf.Max(curValue - amount, 0.0f);
    }

    public float GetPercentage()
    {
        return curValue / maxValue;
    }
}


public class PlayerConditions : MonoBehaviour, IDamageable
{
    public Condition health;

    public UnityEvent onTakeDamage;

    void Start()
    {
        health.curValue = health.startValue;
    }

    void Update()
    {
        if(health.curValue == 0.0f) Die();

        health.uiBar.fillAmount = health.GetPercentage();
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Die()
    {
        Debug.Log("죽음!");
    }

    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtrack(damageAmount);
        onTakeDamage?.Invoke();
    }
}
