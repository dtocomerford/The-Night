using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretGun : MonoBehaviour
{
    public GameObject[] bullets;
    public Transform gunEnd;
    public float weaponCoolDown;
    public int numberOfBullets;
    public GameObject bulletPrefab;

    public Turret m_Turret;
    private int m_BulletIndex;
    public float m_Timer = 99;


    // Start is called before the first frame update
    void Start()
    {
        m_Turret = GetComponent<Turret>();

        bullets = new GameObject[numberOfBullets];

        for (int i = 0; i < numberOfBullets; i++)
        {
            bullets[i] = Instantiate(bulletPrefab, gunEnd.position, Quaternion.identity);
            bullets[i].GetComponent<Bullet>().InitialiseBullet(this.gameObject);
            bullets[i].SetActive(false);
        }
    }


    private void Update()
    {
        m_Timer += Time.deltaTime;
    }

    public void Shoot()
    {
        if (m_Turret == null) throw new NullReferenceException("'Turret' script reference is null check " + this.transform.name + " object");
        

        if (m_Timer > weaponCoolDown && m_Turret.isActive == true)
        {
            BulletMovement bulletMovementScript = bullets[m_BulletIndex % numberOfBullets].GetComponent<BulletMovement>();

            if (bulletMovementScript != null)
            {
                bulletMovementScript.target = m_Turret.currentTarget;
            }
            else
            {
                throw new NullReferenceException("'BulletMovement' script reference is null check " + this.transform.name + " object");
            }

            bullets[m_BulletIndex % numberOfBullets].transform.position = gunEnd.position;
            bullets[m_BulletIndex++ % numberOfBullets].SetActive(true);
            m_Timer = 0;
        }
        else
        {
            Debug.Log("Cooling down, the turret is too warm, someone get it a bag of frozen peas");
        }
    }
}
