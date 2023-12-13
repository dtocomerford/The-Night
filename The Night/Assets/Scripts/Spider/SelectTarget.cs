using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTarget : MonoBehaviour
{
    private Spider m_Spider;
    private GameObject m_HomeLocation;

    public List<GameObject> targets;
    public GameObject currentTarget;
        
    // Start is called before the first frame update
    void Start()
    {
        m_Spider = GetComponent<Spider>();
        m_HomeLocation = GameObject.FindGameObjectWithTag("SpiderHome");
        targets = new List<GameObject>(); 
        targets.AddRange(GameObject.FindGameObjectsWithTag("Gate"));
    }

    public GameObject GetTarget()
    {
        currentTarget = targets[0];

        if (currentTarget == null || targets.Count < 1)
        {
            throw new NullReferenceException("newTarget from GetTarget is null, check targets list");
        }
        return currentTarget;
    }

    public GameObject GetHomeLocation() => m_HomeLocation;


    public bool AtTarget()
    {
        if (Vector3.Distance(this.transform.position, currentTarget.transform.position) < 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
