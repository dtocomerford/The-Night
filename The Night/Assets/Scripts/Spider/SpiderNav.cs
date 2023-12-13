using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderNav : MonoBehaviour
{
    private Spider m_Spider;
    public NavMeshAgent agent;

    private void Start()
    {
        m_Spider = GetComponent<Spider>();
    }

    public void SetTarget(GameObject newTarget)
    {
        agent.SetDestination(newTarget.transform.position);
    }

}
