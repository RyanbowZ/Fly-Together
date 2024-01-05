using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForButtonEvents : MonoBehaviour
{

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);

        GameManager.instance.PlayShotAudioSound(0);
    }

    public void QuitGame() {
        Application.Quit();

        GameManager.instance.PlayShotAudioSound(0);
    }

    public void ChangeResolution()
    {
        //4096¡Á3112 3840¡Á2160      2560X1440     1920¡Á1080     1600¡Á900    
        if (GameManager.instance.switcher == 0)
        {
            Screen.SetResolution(1600, 900, Screen.fullScreen);
        }
        else if (GameManager.instance.switcher == 1)
        {
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
        }
        else if (GameManager.instance.switcher == 2)
        {
            Screen.SetResolution(2560, 1440, Screen.fullScreen);
        }
        else if (GameManager.instance.switcher == 3)
        {
            Screen.SetResolution(3840, 2160, Screen.fullScreen);
        }
        else if (GameManager.instance.switcher == 4)
        {
            Screen.SetResolution(4096, 3112, Screen.fullScreen);
        }

        GameManager.instance.switcher++;
        if (GameManager.instance.switcher >= 5)
        {
            GameManager.instance.switcher = 0;
        }

        GameManager.instance.PlayShotAudioSound(0);
    }

    public void ChangeFullScreen() {
        if (GameManager.instance.isFullScreen)
        {
            GameManager.instance.isFullScreen = false;
            Screen.fullScreen = false;
        }
        else {
            GameManager.instance.isFullScreen = true;
            Screen.fullScreen = true;
        }
        GameManager.instance.PlayShotAudioSound(0);
    }

    public void ChangeFXVolumeOnSliderChanged(float _fxv) {
        GameManager.instance.SetFxVolume(_fxv);
    }

    public void ChangeMusicVolumeOnSliderChanged(float _msc)
    {
        GameManager.instance.SetMscVolume(_msc);
    }
}
