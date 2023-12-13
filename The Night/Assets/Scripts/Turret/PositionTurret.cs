using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTurret : MonoBehaviour
{

    public GameObject turretPrefab;
    public bool turretToPosition = false;
    public float modifer;
    public Vector3 newRotation;

    private Vector3 m_MousePosition;
    private GameObject m_NewTurret;

    private void Update()
    {
        PlaceTurret();
    }

    public void BuildTurret()
    {
        m_NewTurret = Instantiate(turretPrefab, new Vector3(0, 0, -12), Quaternion.identity);
        turretToPosition = true;
    }

    public void PlaceTurret()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;

        mouseScreenPosition.z = mouseScreenPosition.y * modifer;

        m_MousePosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);


        if (turretToPosition)
        {

            Vector3 newPosition = new Vector3(m_MousePosition.x, 0, m_MousePosition.z);
            m_NewTurret.transform.position = newPosition;

            if (Input.GetMouseButton(0))
            {
                turretToPosition = false;
            }
       
            float y = 20 * Input.mouseScrollDelta.y;
            newRotation += new Vector3(m_NewTurret.transform.rotation.x, y, m_NewTurret.transform.rotation.z);

            m_NewTurret.transform.eulerAngles = newRotation;
        }
    }
}
