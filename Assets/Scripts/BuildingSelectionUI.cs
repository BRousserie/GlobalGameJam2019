using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSelectionUI : MonoBehaviour
{
    public GameObject BuildingPrefab;

    public void SelectBuilding()
    {
        Building.selectedBuilding = BuildingPrefab;
    }
}
