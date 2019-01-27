using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Pause : MonoBehaviour
{
    public bool paused = false;
    public GameObject pauseButton;
    public GameObject resumeButton;
    public GameObject quitButton;
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
            resumeButton.SetActive(true);
            quitButton.SetActive(true);
            paused = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            Time.timeScale = 1;
            pauseButton.SetActive(true);
            resumeButton.SetActive(false);
            quitButton.SetActive(false);
            paused = false;
        }
    }
    
    public void OnClickQuit()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void OnClickResume()
    {
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        quitButton.SetActive(false);
        paused = false;
    }

    public void OnClickPause()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        quitButton.SetActive(true);
        paused = true;
    }
}
