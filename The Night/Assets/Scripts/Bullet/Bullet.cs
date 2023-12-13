using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletMovement bulletMovement;
    public Health targetHealth;
    public float bulletDamage;



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            targetHealth = other.GetComponent<Health>();
            targetHealth.TakeDamage(bulletDamage);
            bulletMovement.DeactivateBullet();
            SettlementStats.instance.IncreaseCurrency();
        }
    }
}
