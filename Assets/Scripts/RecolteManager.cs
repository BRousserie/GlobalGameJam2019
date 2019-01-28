using UnityEngine;

public class RecolteManager : MonoBehaviour
{
    public GameObject treeUi;
    GameObject targetTree;

    Character player;
    StatsUI statsUI;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Character>();
        statsUI = GameObject.FindObjectOfType<StatsUI>();
        print("started");
    }

    public void Recolter()
    {
        if (targetTree == null)
            return;

        player.addResources(ResourceType.Wood, 15);
        statsUI.UpdateInfos();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter");
        ShowTreeUi(true, other);
    }

    private void OnTriggerExit(Collider other)
    {
        ShowTreeUi(false, other);
    }

    void ShowTreeUi(bool active, Collider other)
    {
        treeUi.SetActive(active);
        if (active)
            targetTree = other.gameObject;
        else
            targetTree = null;
    }
}
