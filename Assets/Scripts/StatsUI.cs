using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public Text MoneyAmount;
    public Text WoodAmount;
    public Character Player;

    private void Start()
    {
        UpdateInfos();
    }

    public void UpdateInfos()
    {
        MoneyAmount.text = ""+ Player.Resources[(int)ResourceType.Money].Value;
        WoodAmount.text = "" + Player.Resources[(int)ResourceType.Wood].Value;
    }
}
