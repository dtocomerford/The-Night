using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{

    private Turret m_Turret;
    private Vector3 m_DirectionToFace;


    // Start is called before the first frame update
    void Start()
    {
        m_Turret = GetComponent<Turret>();
    }


    public void LookAtTarget()
    {
        if (m_Turret.currentTarget != null)
        {
            m_DirectionToFace = m_Turret.currentTarget.transform.position - transform.position;
            m_DirectionToFace.Normalize();

            float yaw = Mathf.Atan2(m_DirectionToFace.x, m_DirectionToFace.z) * Mathf.Rad2Deg;

            transform.eulerAngles = new Vector3(transform.rotation.x, yaw, transform.rotation.z);
        }
    }
}
