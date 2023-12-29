using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletParent;
    public Turret parentTurret;
    public BulletMovement bulletMovement;
    public Health targetHealth;

    public void InitialiseBullet(GameObject parent)
    {
        bulletParent = parent;
        parentTurret = parent.GetComponent<Turret>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            targetHealth = other.GetComponent<Health>();
            targetHealth.TakeDamage(parentTurret.damage);
            bulletMovement.DeactivateBullet();
            SettlementStats.instance.IncreaseCurrency();
        }
    }
}
