using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSelectionUI : MonoBehaviour
{
    public GameObject BuildingPrefab;
    public Text DescriptionText;
    public GameObject DescriptionPanel;

    public void SelectBuilding()
    {
        Building.selectedBuilding = BuildingPrefab;
    }
    

    public void mouseHover()
    {
        Building building = BuildingPrefab.GetComponent<Building>();
        DescriptionText.text = "Costs : \n"
            + "  Money = " + building.Costs[(int)ResourceType.Money].Value + "\n"
            + "  Wood = " + building.Costs[(int)ResourceType.Wood].Value + "\n"
            + "Health = " + building.Health + "\n";

        Military military = BuildingPrefab.GetComponent<Military>();
        if (military != null)
            DescriptionText.text += "Damages = " + military.Damages + "\n"
                + "Rate of fire = " + military.ShootingRate;

        Commercial commercial = BuildingPrefab.GetComponent<Commercial>();
        if (commercial != null)
            DescriptionText.text += "Earnings = " + commercial.Outcome + "\n"
                + "  each " + commercial.Delay + "s";

        DescriptionPanel.SetActive(true);
    }

    public void mouseStoppedHovering()
    {
        DescriptionPanel.SetActive(false);
    }
}
