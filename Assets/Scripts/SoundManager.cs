using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public SoundItem[] soundItems;

    void Awake()
    {

        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    public void PlaySound(string soundName)
    {
        for (int i = 0; i < soundItems.Length; i++)
        {
            if (soundItems[i].soundName.Equals(soundName))
            {
                soundItems[i].audioSource.Play();
                return;
            }
        }
    }

    public void StopAll()
    {
        for (int i = 0; i < soundItems.Length; i++)
        {
            if (soundItems[i].audioSource.isPlaying)
                soundItems[i].audioSource.Stop();
        }
    }

}

[System.Serializable]
public class SoundItem
{
    public string soundName;
    public AudioSource audioSource;
}