using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SettlementStats : MonoBehaviour
{
    public static SettlementStats instance;

    public int population = 5;
    public int currency = 150;

    public UnityEvent onCurrencyIncrease;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void IncreaseCurrency(int value = 10)
    {
        currency += value;
        onCurrencyIncrease.Invoke();
    }

}
