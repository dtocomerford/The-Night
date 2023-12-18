using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAttack : MonoBehaviour
{
    public Health targetHealth;
    public float bodyAttackDamage;

    private Spider m_Spider;

    private void Start()
    {
        m_Spider = GetComponent<Spider>();

        //Add listener to the OnAttack event on the spiders animation player, this way damage will be taken at a
        //specific time during the attack animation
        m_Spider.animationPlayer.OnAttack.AddListener(BodyAttack);
    }

    public void BodyAttack()
    {
        if (m_Spider.CurrentTarget == null)
        {
            throw new NullReferenceException(this.transform.name + " has no current target");
        }

        targetHealth = m_Spider.CurrentTarget.GetComponent<Health>();
        targetHealth.TakeDamage(bodyAttackDamage);
        //Debug.Log($"BodyAttack {bodyAttackDamage}");
    }

    public void LaserAttack()
    {
        
    }
}
