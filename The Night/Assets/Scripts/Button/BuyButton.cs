using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public PositionTurret positionTurret;
    public int cost;
    public StatsUI statsUI;

    private void Start()
    {
        positionTurret = FindObjectOfType<PositionTurret>();
    }

    public void BuyTurret()
    {
        if (SettlementStats.instance.currency > cost)
        {
            SettlementStats.instance.currency -= cost;
            statsUI.UpdateStatsUI();
            positionTurret.BuildTurret();
        }
        else
        {
            statsUI.StartColorChangeCoroutine();
        }
    }

    
}
