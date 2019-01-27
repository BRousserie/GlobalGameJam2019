using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject groupMainMenu;
    public GameObject groupCredits;
    public GameObject planetMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClickPlay()
    {
        SoundManager.instance.PlaySound("Click_Sound");
        SceneManager.LoadScene("Game");
        SoundManager.instance.StopAll();
        SoundManager.instance.PlaySound("Music_Jeu_Calme");
    }

    public void OnClickQuit()
    {
        SoundManager.instance.PlaySound("Click_Sound");
        Application.Quit();
        // Application.Quit ne fonctionne que sur une version Build (un .exe) du jeu. 
        // Pour faire ça dans UnityEditor, c'est avec :
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void OnClickCredits()
    {
        SoundManager.instance.PlaySound("Click_Sound");
        groupMainMenu.SetActive(false);
        planetMenu.SetActive(false);
        groupCredits.SetActive(true);

    }

    public void OnClickBack()
    {
        SoundManager.instance.PlaySound("Click_Sound");
        groupCredits.SetActive(false);
        planetMenu.SetActive(true);
        groupMainMenu.SetActive(true);
    }
}
