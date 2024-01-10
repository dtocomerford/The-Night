using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Formats.Alembic.Importer;

public class CitizenAnimationPlayer : MonoBehaviour
{
    #region PRIVATE VARIABLE
    private AlembicStreamPlayer m_Player;

    //Walk animation
    [SerializeField]
    private float m_WallAnimationSpeed;
    [SerializeField]
    private float m_WalkAnimationStart;
    [SerializeField]
    private float m_WalkAnimationEnd;

    private float m_T = 0;
    #endregion

    #region EXECUTION
    // Start is called before the first frame update
    void Start()
    {
        m_Player = GetComponentInChildren<AlembicStreamPlayer>();
    }
    #endregion


    #region ANIMATIONS
    public void WalkAnimation()
    {
        m_T += (Time.deltaTime * m_WallAnimationSpeed);

        m_Player.CurrentTime = Mathf.Lerp(m_WalkAnimationStart, m_WalkAnimationEnd, m_T);

        if (m_T > 1)
        {
            m_T = 0;
        }
    }
    #endregion
}
