using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateUI : MonoBehaviour
{
    public Canvas canvas;
    private Enitity m_Entity;

    private void Start()
    {
        m_Entity = GetComponent<Enitity>();
        canvas.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Enemy" && m_Entity.entityHealth.destroyed == false)
        {
            canvas.enabled = true;
        }
    }
}
