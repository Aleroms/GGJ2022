using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; 
    
    public static AudioManager instance;

    private float fadeDuration = 0.6f;
    private int sceneIndex = 0;

    private void Awake() 
    {
        if (instance== null) 
        {
            instance = this;
        } else 
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds) 
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start() 
    {
         sceneIndex = SceneManager.GetActiveScene().buildIndex;
        
    }
    private IEnumerator MenuWaitCoroutine()
    {
        Play("menu-intro");
        yield return new WaitForSeconds(40.21f);
        Play("menu-loop");
    }

    public void LevelSpecificPlay(int sceneIndex) 
    {
        
        switch(sceneIndex) 
        {
            case 0:
                StartCoroutine(MenuWaitCoroutine());
                break;
        }
    }
    

    public void SetVolume(float volume) 
    {
        foreach (Sound s in sounds) 
        {
            s.source.volume = volume;
        }
    }

    public void Play(string name) 
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s != null)
            s.source.Play();
        else
            Debug.LogWarning("audioclip " + name + " is NULL");

        Debug.Log("playing: " + name);
    }

    public void Stop(string name) 
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s != null)
            s.source.Stop();
        else
            Debug.LogWarning("audioclip " + name + " is NULL");
    }
    public void StopMenu()
	{
        Stop("menu-loop");
        Stop("menu-intro");
	}

    public void SettingsButton(float volume) 
    {
        foreach (Sound s in sounds) 
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.volume = volume;
        }
    }

    public void FadeIn(string name) 
    {
        StartCoroutine(FadeIn(name, fadeDuration));
    }

    public void FadeOut(string name) 
    {
        StartCoroutine(FadeOut(name, fadeDuration));
    }

    public IEnumerator FadeIn(string name, float FadeTime) 
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s != null) 
        {
            s.source.Play();
            s.source.volume = 0f;

            while (s.source.volume < 1) 
            {
                s.source.volume += Time.deltaTime / FadeTime;
                yield return null;
            }
        }
    }

    public IEnumerator FadeOut(string name, float FadeTime) 
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s != null) 
        {
            float startVolume = s.source.volume;
            while (s.source.volume > 0) 
            {
                s.source.volume -= startVolume * Time.deltaTime / FadeTime;
                yield return null;
            }
            s.source.Stop();
        }
    }
}
