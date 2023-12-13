using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Formats.Alembic.Importer;

public class SpiderAnimationPlayer : MonoBehaviour
{
    #region PRIVATE VARIABLE
    private AlembicStreamPlayer m_Player;
    private Spider m_Spider;

    //Walk animation
    [SerializeField]
    private float m_WallAnimationSpeed;
    [SerializeField]
    private float m_WalkAnimationStart;
    [SerializeField]
    private float m_WalkAnimationEnd;

    //Attack animation
    [SerializeField]
    private float m_AttackAnimationSpeed;
    [SerializeField]
    private float m_AttackAnimationStart;
    [SerializeField]
    private float m_AttackAnimationEnd;
    [SerializeField]
    private float m_AttackAnimationHitGround = 2.922139f;

    private Coroutine m_AttackCoroutine = null;
    private float m_T = 0;

    public UnityEvent OnAttack;
    #endregion

    #region EXECUTION
    // Start is called before the first frame update
    void Start()
    {
        m_Spider = GetComponent<Spider>();
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


    /// <summary>
    /// Utility function to start the coroutine 
    /// </summary>
    public void StartAttackCoroutine()
    {
        if (m_AttackCoroutine == null)
        {
            m_AttackCoroutine = StartCoroutine(AttackAnimation());
        }
    }


    /// <summary>
    /// Using a coroutine so the animation can play and other tasks can be completed asynchronously
    /// </summary>
    private IEnumerator AttackAnimation()
    {
        m_Player.CurrentTime = m_AttackAnimationStart;
        bool attackLanded = false;

        while (m_Player.CurrentTime < m_AttackAnimationEnd)
        {
            //When the animation reaches the point where the spider hits the ground
            if (!attackLanded && m_Player.CurrentTime > m_AttackAnimationHitGround)
            {
                //Invoke OnAttack so damage is taken at the logical part of the animation
                OnAttack.Invoke();
                attackLanded = true;
            }

            m_Player.CurrentTime += (Time.deltaTime * m_AttackAnimationSpeed);
            yield return null;
            
        }
        m_AttackCoroutine = null;
    }
    #endregion
}
