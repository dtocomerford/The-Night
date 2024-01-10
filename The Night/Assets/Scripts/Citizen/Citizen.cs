using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : Base
{
    public CitizenStateMachine citizenStateMachine;
    public CitizenAnimationPlayer animationPlayer;
    public WalkToPoints walkToPoints;

    [SerializeField]
    private GameObject m_CurrentTarget;

    public GameObject CurrentTarget
    {
        get { return m_CurrentTarget; }
        set { m_CurrentTarget = value; }
    }
}
