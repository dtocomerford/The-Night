using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : Health
{
    public bool destroyed;
    private Enitity m_Entity;
    
    // Start is called before the first frame update
    void Start()
    {
        destroyed = false;
        m_Entity = GetComponent<Enitity>();

        CurrentHealth = MaxHealth;
    }


    public override void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            destroyed = true;
            CurrentHealth = 0;
            //Disable the health bar canvas if the object has been destroyed
            m_Entity.healthBarUI.healthBarCanvas.enabled = false;
            Break();
        }

        if (m_Entity.healthBarUI.healthBar == null)
        {
            throw new NullReferenceException("Health bar UI reference is null check " + this.transform.name + " object");
        }

        m_Entity.healthBarUI.UpdateHealth();
    }

    public void Break()
    {
        //Debug.Log("Break called");
        m_Entity.particleSystemController.ActivateSystems();

        if (this.GetComponent<MeshRenderer>() != null)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
        m_Entity.healthBarUI.healthBarCanvas.enabled = false;
        //Use delegate to invoke other functions, animations
    }

}
//possible ideas - spider shoots laser, wall can be damaged, maker multiple prefabs of the wall in different conditions
//create settlers, make them stupid, if wall breaks they run out, game over when all the settlers are dead
//have settlers come by each round, either let them in which costs money so less can be spent on defence, watch them die if you
//leave them outside