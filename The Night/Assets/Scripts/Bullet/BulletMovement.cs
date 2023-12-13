using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed;
    public float bulletLifeTime;
    public GameObject target;

    private float m_Timer;



    // Update is called once per frame
    void Update()
    {
        m_Timer += Time.deltaTime;

        if (m_Timer > bulletLifeTime)
        {
            DeactivateBullet();
            m_Timer = 0;
        }

        var step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }

    public void DeactivateBullet()
    {
        gameObject.SetActive(false);
    }
}
