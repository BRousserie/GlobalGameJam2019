using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public Text MoneyAmount;
    public Text WoodAmount;
    public Text Score;
    Character Player;

    private void Start()
    {
        Player = GameObject.FindObjectOfType<Character>();
        UpdateInfos();
    }

    public void UpdateInfos()
    {
        MoneyAmount.text = ""+ Player.Resources[(int)ResourceType.Money].Value;
        WoodAmount.text = "" + Player.Resources[(int)ResourceType.Wood].Value;
        Score.text = "" + Character.instance.score;
    }
}
