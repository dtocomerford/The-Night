using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenStateMachine : MonoBehaviour
{
    public GameObject newTarget;
    private Citizen m_Citizen;

    enum State
    {
        Idle,
        Attack,
        Flee,
        Chase,
        Wonder
    }

    State citizenState = State.Idle;

    // Start is called before the first frame update
    void Start()
    {
        m_Citizen = GetComponent<Citizen>();
    }

    // Update is called once per frame
    void Update()
    {
        

        switch (citizenState)
        {
            case State.Idle:
                if (m_Citizen.CurrentTarget != null)
                {
                    citizenState = State.Wonder;
                }
                else
                {
                    m_Citizen.CurrentTarget = m_Citizen.walkToPoints.GetWaypoint();
                }
                Debug.Log("Idle");
                break;


            case State.Attack:

                Debug.Log("Attack");
                break;


            case State.Flee:
                break;


            case State.Chase:
                
                
                Debug.Log("Chase");
                
                break;

            case State.Wonder:

                if (m_Citizen.CurrentTarget != null)
                {
                    m_Citizen.navigation.SetTarget(m_Citizen.CurrentTarget);
                }

                if (m_Citizen.walkToPoints.AtTarget(m_Citizen.CurrentTarget))
                {
                    newTarget = m_Citizen.walkToPoints.GetWaypoint();

                    if (newTarget == null)
                    {
                        Debug.Log("No new target found");
                    }

                    m_Citizen.CurrentTarget = newTarget;
                    m_Citizen.navigation.SetTarget(m_Citizen.CurrentTarget);
                }

                
                Debug.Log("Wonder");

                break;

            default:
                Debug.Log("We made it down to default");
                break;
        }
    }
}
