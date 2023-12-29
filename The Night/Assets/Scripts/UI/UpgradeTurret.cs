using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTurret : MonoBehaviour
{

    private Turret m_Turret;
    public Text currentRangeText;
    public Text currentDamageText;


    // Start is called before the first frame update
    void Start()
    {
        m_Turret = GetComponent<Turret>();
    }

    public void UpdateRangeText()
    {
        currentRangeText.text = "Range: " + m_Turret.range.ToString();
    }

    public void UpdateDamageText()
    {
        currentRangeText.text = "Damage: " + m_Turret.damage.ToString();
    }
}
