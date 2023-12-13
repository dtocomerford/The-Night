using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderHealth : Health
{

    private Spider m_Spider;

    // Start is called before the first frame update
    void Start()
    {
        m_Spider = GetComponent<Spider>();
        CurrentHealth = MaxHealth;
    }

    public override void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
        }

        if (m_Spider.healthBarUI.healthBar == null)
        {
            throw new NullReferenceException("Health bar UI reference is null check " + this.transform.name + " object");
        }

        m_Spider.healthBarUI.UpdateHealth();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed");
            this.TakeDamage(20);
        }
    }
}
