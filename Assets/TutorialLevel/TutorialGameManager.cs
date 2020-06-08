using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialGameManager : MonoBehaviour
{
    [SerializeField] private GameObject player, deathMessage, pauseMenu, endMenuScreen;
    [SerializeField] private Text endMenuScore, endMenuTotal;
    [SerializeField] private Transform[] checkpoints;
    [SerializeField] private int totalBeans, checkpoint;
    [SerializeField] private Animator pAnimator, cmAnimator;
    [SerializeField] private TutorialEndCutsceneManager endCutscene;
    private TutorialInputManager iManager;
    private int beanCount = 0;
    public bool paused = false, dead = false;
    // Start is called before the first frame update
    void Start()
    {
        iManager = gameObject.GetComponent<TutorialInputManager>();
        player.transform.position = checkpoints[0].position;
        deathMessage.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        endMenuTotal.text = "out of " + totalBeans + " Coffee Beans.";
        checkpoint = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Respawn()
    {
        player.transform.position = checkpoints[checkpoint].position;
        pAnimator.SetTrigger("respawn");
        iManager.UnFreeze();
        deathMessage.SetActive(false);
        pauseMenu.SetActive(false);
        dead = false;
        Time.timeScale = 1;
    }

    public void NextCheckpoint()
    {
        checkpoint++;
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

    public void EndLevel()
    {
        iManager.Freeze();
        endCutscene.StartEndCutscene();
    }
    public void EndLevelScreen()
    {
        endMenuScore.text = "You collected " + beanCount;
        endMenuScreen.SetActive(true);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        iManager.Freeze();
        Time.timeScale = 0;
        paused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        iManager.UnFreeze();
        Time.timeScale = 1;
        paused = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        endMenuScreen.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        endMenuScreen.SetActive(false);
        SceneManager.LoadScene(5);
    }
}
