using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public GameObject tipPanel;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void StartTheGame()
    {
        Time.timeScale = 1f;
        tipPanel.SetActive(false);
    }
}
