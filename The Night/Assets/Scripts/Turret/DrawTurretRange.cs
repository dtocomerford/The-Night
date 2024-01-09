using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTurretRange : MonoBehaviour
{

    public int vertexCount = 40;
    public float radius = 2f;

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        DrawCircle();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void DrawCircle()
    {
        lineRenderer.positionCount = vertexCount;

        for (int i = 0; i < vertexCount; i++)
        {
            float angle = (float)i / vertexCount * 360;
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            lineRenderer.SetPosition(i, (new Vector3(x, 0.25f, y) + this.transform.position));
        }
    }
}
