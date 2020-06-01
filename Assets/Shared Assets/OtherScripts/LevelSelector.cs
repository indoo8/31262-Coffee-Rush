using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void TutorialLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void RileyLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void HeinLevel()
    {
       // SceneManager.LoadScene(2);
    }

    public void JakeLevel()
    {
       // SceneManager.LoadScene(2);
    }

    public void GavinLevel()
    {
        //SceneManager.LoadScene(2);
    }


    public void quitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}
