using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Pause : MonoBehaviour
{
    public bool paused = false;
    public GameObject pauseButton;
    public GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            Time.timeScale = 0;
            pauseButton.SetActive(false);
            pausePanel.SetActive(true);
            paused = true;
        }else if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            Time.timeScale = 1;
            pauseButton.SetActive(true);
            pausePanel.SetActive(false);
            paused = false;
        }
    }
    
    public void OnClickQuit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main_Menu");
    }

    public void OnClickResume()
    {
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
        paused = false;
        Building.selectedBuilding = null; //sinon on pose un bâtiment en dessous de nous
    }

    public void OnClickPause()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
        paused = true;
    }
}
