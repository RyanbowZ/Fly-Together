using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int switcher;
    public AudioSource[] audios;
    public AudioSource[] musics;
    public bool isFullScreen = true;
    public float fxVolume;
    public float mscVolume;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            if (instance != this) {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
        Screen.fullScreen = true;
        isFullScreen = true;
    }

    public void PlayShotAudioSound(int audioID) {
        audios[audioID].Play();
    }

    public void PlayShotMusicSound(int musicID) {
        foreach (var item in musics)
        {
            if (item.isPlaying) {
                item.Stop();
            }
        }
        musics[musicID].Play();
    }

    public void SetFxVolume(float _setter) {
        GameManager.instance.fxVolume = _setter;
        SetAudioSound();
    }

    public void SetMscVolume(float _setter)
    {
        GameManager.instance.mscVolume = _setter;
        SetMusicSound();
    }

    private void SetAudioSound() {
        foreach (var item in audios)
        {
            item.volume = fxVolume;
        }
    }

    private void SetMusicSound()
    {
        foreach (var item in musics)
        {
            item.volume = mscVolume;
        }
    }
}
