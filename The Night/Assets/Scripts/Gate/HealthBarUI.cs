using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    
    public Image healthBar;
    public Canvas healthBarCanvas;

    public Health m_Health;

    // Start is called before the first frame update
    void Start()
    {
        m_Health = GetComponent<Health>();
        healthBar.fillAmount = m_Health.MaxHealth;
    }

    // Update is called once per frame
    public void UpdateHealth()
    {
        healthBar.fillAmount = m_Health.CurrentHealth / 100;
    }
}
