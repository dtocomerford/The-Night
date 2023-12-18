using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public TurretStateMachine turretStateMachine;
    public TurretGun turretGun;
    public TurretRotation turretRotation;
    public GetTarget getTarget;
    public GameObject currentTarget;

    public bool isActive;


    private void Start()
    {
        isActive = false;
    }
}
