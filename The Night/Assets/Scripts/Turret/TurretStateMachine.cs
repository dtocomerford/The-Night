using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretStateMachine : MonoBehaviour
{
    private Turret m_Turret;

    enum State
    {
        Idle,
        Attack,
    }

    State turretState = State.Idle;


    // Start is called before the first frame update
    void Start()
    {
        m_Turret = GetComponent<Turret>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (turretState)
        {
            case State.Idle:
                
                if (m_Turret.currentTarget != null)
                {
                    turretState = State.Attack;
                }
                break;


            case State.Attack:

                m_Turret.turretRotation.LookAtTarget();
                m_Turret.turretGun.Shoot();

                if (m_Turret.currentTarget == null)
                {
                    turretState = State.Idle;
                }
                break;

            default:
                break;
        }
    }
}
