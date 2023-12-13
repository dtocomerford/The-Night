using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderStateMachine : MonoBehaviour
{
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

        if (Input.GetKeyDown(KeyCode.F) || m_Spider.spiderHealth.CurrentHealth <=0)
        {
            spiderState = State.Flee;
        }

        switch (spiderState)
        {
            case State.Idle:
                break;

            case State.Attack:
                m_Spider.animationPlayer.StartAttackCoroutine();

                if (m_Spider.CurrentTarget.GetComponent<Health>().CurrentHealth <=0)
                {
                    spiderState = State.Flee;
                }
                break;

            case State.Flee:
                m_Spider.animationPlayer.WalkAnimation();
                m_Spider.spiderNav.SetTarget(m_Spider.selectTarget.GetHomeLocation());
                break;

            case State.Chase:
                m_Spider.animationPlayer.WalkAnimation();
                m_Spider.CurrentTarget = m_Spider.selectTarget.GetTarget();
                m_Spider.spiderNav.SetTarget(m_Spider.CurrentTarget);
   
                if (m_Spider.selectTarget.AtTarget())
                {
                    spiderState = State.Attack;
                }
                break;

            default:
                Debug.Log("We made it down to default");
                break;
        }
    }
}
