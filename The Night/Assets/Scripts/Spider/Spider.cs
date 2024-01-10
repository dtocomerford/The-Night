using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Base
{
    public SpiderStateMachine spiderStateMachine;
    public SpiderAnimationPlayer animationPlayer;
    public SpiderAttack spiderAttack;
    public HealthBarUI healthBarUI;

    [SerializeField]
    private GameObject m_CurrentTarget;

    public GameObject CurrentTarget
    {
        get { return m_CurrentTarget; }
        set { m_CurrentTarget = value; }
    }
}
