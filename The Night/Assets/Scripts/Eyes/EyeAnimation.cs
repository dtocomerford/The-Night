using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Formats.Alembic.Importer;

public class EyeAnimation : MonoBehaviour
{
    [SerializeField]
    private float m_AnimationStartTime;
    [SerializeField]
    private float m_AnimationEndTime;
    [SerializeField]
    private float m_AnimationSpeed;

    private AlembicStreamPlayer m_Player;


    // Start is called before the first frame update
    void Start()
    {
        m_Player = GetComponent<AlembicStreamPlayer>();
        m_Player.CurrentTime = m_AnimationStartTime;
    }

    // Update is called once per frame
    void Update()
    {
        PlayAnimation();
    }

    void PlayAnimation()
    {
        m_Player.CurrentTime += (Time.deltaTime * m_AnimationSpeed);


        if (m_Player.CurrentTime > m_AnimationEndTime)
        {
            m_Player.CurrentTime = m_AnimationStartTime;
        }
    }
}
