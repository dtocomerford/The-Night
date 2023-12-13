using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateUI : MonoBehaviour
{
    public Canvas canvas;

    private void Start()
    {
        canvas.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Called");
        if (other.tag == "Enemy")
        {
            canvas.enabled = true;
        }
    }
}
