using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTarget : MonoBehaviour
{
    private Spider m_Spider;
    private GameObject m_HomeLocation;

    public List<GameObject> bases;
    public List<GameObject> barriers;
    public GameObject newTarget;
    public bool barriersBreached;    

    // Start is called before the first frame update
    void Start()
    {
        barriersBreached = false;
        //m_Spider = GetComponent<Spider>();
        m_HomeLocation = GameObject.FindGameObjectWithTag("SpiderHome");
        bases = new List<GameObject>(); 
        bases.AddRange(GameObject.FindGameObjectsWithTag("Base"));
        barriers.AddRange(GameObject.FindGameObjectsWithTag("Gate"));
    }

    /// <summary>
    /// Returns a gameobject which will be the next target position to move to
    /// </summary>
    /// <returns></returns>
    public GameObject GetTarget()
    {
        newTarget = null;

        if (CheckForBreach())
        {
            foreach (GameObject obj in bases)
            {
                if (obj.GetComponent<Health>().CurrentHealth > 0)
                {
                    newTarget = obj;
                    //Debug.Log("New target: " + newTarget.name + " health: " + newTarget.GetComponent<Health>().CurrentHealth);
                }
            }
        }
        else
        {
            foreach (GameObject obj in barriers)
            {
                if (obj.GetComponent<Health>().CurrentHealth > 0)
                {
                    newTarget = obj;
                    //Debug.Log("New target: " + newTarget.name + " health: " + newTarget.GetComponent<Health>().CurrentHealth);
                }
            }
        }

        if (newTarget == null)
        {
            Debug.Log("Target returned null");
            return null;
        }

        return newTarget;
    }

    public GameObject GetHomeLocation() => m_HomeLocation;


    public bool AtTarget(GameObject target)
    {
        if (Vector3.Distance(this.transform.position, target.transform.position) < 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckForBreach()
    {
        foreach (GameObject barrier in barriers)
        {
            if (barrier.GetComponent<Health>().CurrentHealth <= 0)
            {
                barriersBreached = true;
            }
        }
        return barriersBreached;
    }
}
