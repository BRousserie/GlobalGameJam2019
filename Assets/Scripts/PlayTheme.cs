using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTheme : MonoBehaviour
{
    public string MusicName;

    private void Start()
    {
        Play();
    }

    public void Play()
    {
        SoundManager.instance.StopAll();
        SoundManager.instance.PlaySound(MusicName);
    }
}
