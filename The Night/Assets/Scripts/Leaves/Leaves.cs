using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaves : MonoBehaviour
{
    public Vector3 startScale;


    // Start is called before the first frame update
    void Start()
    {
        startScale = this.transform.localScale;
    }
}
