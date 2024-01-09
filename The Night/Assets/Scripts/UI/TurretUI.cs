using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUI : MonoBehaviour
{
    public GameObject menu;

    public void EnableUI()
    {
        Debug.Log("CLICKED");
        if (menu.activeInHierarchy == false)
        {
            menu.SetActive(true);
            Debug.Log("UI ENABLED");
        }   
    }
}
