using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHealth : Health
{
    private Gate m_Gate;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Gate = GetComponent<Gate>();

        CurrentHealth = MaxHealth;
    }

    public override void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Break();
        }

        if (m_Gate.healthBarUI.healthBar == null)
        {
            throw new NullReferenceException("Health bar UI reference is null check " + this.transform.name + " object");
        }

        m_Gate.healthBarUI.UpdateHealth();
    }

    public void Break()
    {
        Debug.Log("Break called");
        m_Gate.particleSystemController.ActivateSystems();
        this.GetComponent<MeshRenderer>().enabled = false;
        m_Gate.healthBarUI.healthBarCanvas.enabled = false;
        //Use delegate to invoke other functions, animations
    }

}
//possible ideas - spider shoots laser, wall can be damaged, maker multiple prefabs of the wall in different conditions
//create settlers, make them stupid, if wall breaks they run out, game over when all the settlers are dead
//have settlers come by each round, either let them in which costs money so less can be spent on defence, watch them die if you
//leave them outside