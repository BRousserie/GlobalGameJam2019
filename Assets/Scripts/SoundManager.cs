using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager instance;
	public SoundItem [] soundItems;

	void Awake(){
		if(instance == null){
			DontDestroyOnLoad(gameObject);
			instance = this;
		}else if(instance != this){
			Destroy(gameObject);
		}
	}


    // Start is called before the first frame update
    void PlaySound(string soundName)
    {
        
    }
}

[System.serialized]
public class SoundItem
{
	public string soundName;
	public AudioSource audioSource;
}