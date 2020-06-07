using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GavinGameManager : MonoBehaviour
{
    [SerializeField] private GameObject player, deathMessage, pauseMenu, endMenuScreen;
    [SerializeField] private Transform playerStartPos;
    [SerializeField] private Text endMenuScore, endMenuTotal;
    [SerializeField] private int totalBeans;
    [SerializeField] private GameObject[] coffeeBeans;
    [SerializeField] private Animator pAnimator, cmAnimator;
    private GavinInputManager iManager;
    private int beanCount = 0;
    public bool paused = false, dead = false;

    void Start()
    {
        iManager = gameObject.GetComponent<GavinInputManager>();
        player.transform.position = playerStartPos.position;
        deathMessage.SetActive(false);
        pauseMenu.SetActive(false);
        endMenuScreen.SetActive(false);
        Time.timeScale = 1;
        endMenuTotal.text = "out of " + totalBeans + " Coffee Beans.";

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Respawn()
    {
        pAnimator.SetTrigger("respawn");
        player.transform.position = playerStartPos.position;
        iManager.UnFreeze();
        deathMessage.SetActive(false);
        pauseMenu.SetActive(false);
        endMenuScreen.SetActive(false);
        dead = false;
        Time.timeScale = 1;
        for (int i = 0; i < coffeeBeans.Length; i++)
        {
            coffeeBeans[i].SetActive(true);
        }
    }

    public void PlayerDie()
    {
        pAnimator.SetTrigger("dead");
        iManager.Freeze();
        deathMessage.SetActive(true);
        dead = true;
    }

    public void CollectBean()
    {
        beanCount++;
        //Debug.Log("beanCount = " + beanCount);
    }
    public void EndLevelScreen()
    {
        endMenuScore.text = "You collected " + beanCount;
        endMenuScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void PauseGame()
    {
        Debug.Log("Paused");
        pauseMenu.SetActive(true);
        iManager.Freeze();
        Time.timeScale = 0;
        paused = true;
    }

    public void ResumeGame()
    {
        Debug.Log("Resumed");
        pauseMenu.SetActive(false);
        iManager.UnFreeze();
        Time.timeScale = 1;
        paused = false;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();

    }
}
