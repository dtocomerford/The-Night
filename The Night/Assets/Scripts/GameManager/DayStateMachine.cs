using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayStateMachine : MonoBehaviour
{
    private DayTransition m_DayTransition;

    public enum State
    {
        Day,
        Night
    }

    public State cycle = State.Night;

    // Start is called before the first frame update
    void Start()
    {
        m_DayTransition = GetComponent<DayTransition>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (cycle)
        {
            case State.Day:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    cycle = State.Night;
                    m_DayTransition.GoToNight();
                    
                }
                break;
            case State.Night:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    cycle = State.Day;
                    m_DayTransition.GoToDay();
                    
                }
                break;
            default:
                break;
        }
    }
}
