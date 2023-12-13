using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public Text currencyText;
    public Text populationText;

    public Color textStartColor;
    public Color textEndColor;
    public float colorFlashDuration;
    public float speed;

    private float m_Timer;
    private bool m_StatsInitialsed = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (m_StatsInitialsed == false)
        {
            UpdateStatsUI();
            SettlementStats.instance.onCurrencyIncrease.AddListener(UpdateStatsUI);
        }
    }


    public void UpdateStatsUI()
    {
        if (SettlementStats.instance == null)
        {
            throw new NullReferenceException("Settlement instance is null, called from: " + this.transform.name + " object");
        }
        currencyText.text = "Curency: " + SettlementStats.instance.currency.ToString();
        populationText.text = "Population: " + SettlementStats.instance.population.ToString();
        m_StatsInitialsed = true;
    }

    public void StartColorChangeCoroutine()
    {
        StartCoroutine(CurrencyTooLow());
    }

    public IEnumerator CurrencyTooLow()
    {
        int mod = 1;
        m_Timer = 0;
        float t = 0;

        while (m_Timer < colorFlashDuration)
        {
            m_Timer += Time.deltaTime;
            t += Time.deltaTime * mod * speed;

            if (t > 1)
            {
                mod *= -1;
            }

            currencyText.color = Color.Lerp(textStartColor, textEndColor, t);
            yield return null;
        }
        
    }
}
