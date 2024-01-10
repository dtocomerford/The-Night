using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderStateMachine : MonoBehaviour
{
    public GameObject newTarget;
    private Spider m_Spider;

    enum State
    {
        Idle,
        Attack,
        Flee,
        Chase
    }

    State spiderState = State.Idle;

    // Start is called before the first frame update
    void Start()
    {
        m_Spider = GetComponent<Spider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            spiderState = State.Chase;
        }

        if (Input.GetKeyDown(KeyCode.F) || m_Spider.health.CurrentHealth <=0)
        {
            spiderState = State.Flee;
        }

        switch (spiderState)
        {
            case State.Idle:

                if (m_Spider.CurrentTarget != null)
                {
                    spiderState = State.Chase;
                }
                else
                {
                    newTarget = m_Spider.selectTarget.GetTarget();
                    m_Spider.CurrentTarget = newTarget;

                    if (newTarget == null)
                    {
                        spiderState = State.Flee;
                    }
                }

                Debug.Log("Idle");
                break;


            case State.Attack:

                Debug.Log("Attack");

                m_Spider.animationPlayer.StartAttackCoroutine();

                if (m_Spider.CurrentTarget != null && m_Spider.CurrentTarget.GetComponent<Health>().CurrentHealth <=0)
                {
                 
                    m_Spider.CurrentTarget = null;
                    m_Spider.animationPlayer.ResetAttackCoroutine();
                    spiderState = State.Idle;
                }
                break;


            case State.Flee:

                Debug.Log("Flee");
                m_Spider.animationPlayer.WalkAnimation();
                m_Spider.navigation.SetTarget(m_Spider.selectTarget.GetHomeLocation());
                break;


            case State.Chase:

                Debug.Log("Chase");
                m_Spider.animationPlayer.WalkAnimation();
                m_Spider.selectTarget.GetTarget();

                if (m_Spider.CurrentTarget == null)
                {
                    spiderState = State.Flee;
                }
                else
                {
                    m_Spider.navigation.SetTarget(m_Spider.CurrentTarget);

                    if (m_Spider.selectTarget.AtTarget(m_Spider.CurrentTarget))
                    {
                        spiderState = State.Attack;
                    }
                }
                break;

            default:
                Debug.Log("We made it down to default");
                break;
        }
    }
}
