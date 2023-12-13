using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float m_CurrentHealth;
    [SerializeField]
    private float m_MaxHealth;

    public float CurrentHealth
    {
        get { return m_CurrentHealth; }
        set { m_CurrentHealth = value; }
    }

    public float MaxHealth
    {
        get { return m_MaxHealth; }
        set { m_MaxHealth = value; }
    }


    public virtual void TakeDamage(float damage)
    {
        m_CurrentHealth -= damage;

        if (m_CurrentHealth < 0)
        {
            m_CurrentHealth = 0;
        }
    }
}
