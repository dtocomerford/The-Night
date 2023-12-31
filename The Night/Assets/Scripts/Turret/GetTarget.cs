using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTarget : MonoBehaviour
{
    private Turret m_Turret;
    private CapsuleCollider collider;

    private void Start()
    {
        m_Turret = GetComponent<Turret>();
        collider = GetComponent<CapsuleCollider>();
        collider.radius = m_Turret.range;
    }

    private void Update()
    {
        collider.radius = m_Turret.range;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == null)
        {
            throw new NullReferenceException("Collider is null on OnTriggerEnter from: " + this.transform.name + " object");
        }

        if (m_Turret.currentTarget == null && other.tag == "Enemy")
        {
            m_Turret.currentTarget = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (m_Turret.currentTarget != null && other.tag == "Enemy")
        {
            m_Turret.currentTarget = null;
        }
    }
}
