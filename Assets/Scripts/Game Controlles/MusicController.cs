using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
	public static MusicController instance; 

	private AudioSource audioSource;
	// public AudioClip AClip;

	void Awake()
	{
		MakeSingleton();
		audioSource = GetComponent<AudioSource>();
	}

	void MakeSingleton()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	public void PlayMusic(bool play)
	{
		if (play)
		{
			if (!audioSource.isPlaying)
			{
				audioSource.Play();
			}
		}
		else
		{
			if (audioSource.isPlaying)
			{
				audioSource.Stop();
			}
		}
	}
    /*public void PlayBackground()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();

        }
        else
        {
            audioSource.clip = AClip;
            audioSource.Play();
        }

    }*/

}
