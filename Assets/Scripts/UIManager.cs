using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject groupMainMenu;
    public GameObject groupCredits;
    public GameObject planetMenu;
    public GameObject planetCredit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void OnClickCredits()
    {
        groupMainMenu.SetActive(false);
        planetMenu.SetActive(false);
        groupCredits.SetActive(true);
        planetCredit.SetActive(true);

    }

    public void OnClickBack()
    {
        groupCredits.SetActive(false);
        planetCredit.SetActive(false);
        planetMenu.SetActive(true);
        groupMainMenu.SetActive(true);
    }
}
