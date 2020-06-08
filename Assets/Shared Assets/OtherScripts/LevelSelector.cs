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
        SceneManager.LoadScene(4);
    }

    public void HeinLevel()
    {
        SceneManager.LoadScene(3);
    }

    public void JakeLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void GavinLevel()
    {
        SceneManager.LoadScene(5);
    }


    public void quitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
