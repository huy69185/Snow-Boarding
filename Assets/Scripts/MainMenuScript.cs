using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public AudioSource music1;
    public TextMeshProUGUI musicMuteLabel;

    public void GoToScene(string sceneName)
    {
        if (sceneName == "Quit")
        {
            Quit();
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public void Quit()
    {
        UnityEngine.Application.Quit(); 
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
#endif
    }

    public void MuteUnmuteMusic()
    {
        if (music1 != null && musicMuteLabel != null)
        {
            if (music1.isPlaying)
            {
                music1.Pause();
                musicMuteLabel.text = "Play Music";
            }
            else
            {
                music1.Play();
                musicMuteLabel.text = "Mute Music";
            }
        }
    }
}
