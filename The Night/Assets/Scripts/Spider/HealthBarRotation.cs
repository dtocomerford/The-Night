using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarRotation : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.LookAt(Camera.main.transform);
    }
}
