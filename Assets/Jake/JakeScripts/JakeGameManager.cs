using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JakeGameManager : MonoBehaviour
{
    [SerializeField] private GameObject player, deathMessage, pauseMenu, endMenuScreen;
   // [SerializeField] private Transform playerStartPos;
    [SerializeField] private Transform[] checkpoints;
    [SerializeField] private Text endMenuScore, endMenuTotal;
    [SerializeField] private Animator pAnimator, cmAnimator;
    [SerializeField] private int totalBeans, checkpoint;
    [SerializeField] JakeEndCutScene endcutscene;
    private JakeInputManager uManager;
    private int beanCount = 0;
    public bool paused = false, dead = false;
    // Start is called before the first frame update
    void Start()
    {
        //  iManager = gameObject.GetComponent<RileyInputManager>();
        uManager = gameObject.GetComponent<JakeInputManager>();
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
        pAnimator.SetTrigger("respawn");
        player.transform.position = checkpoints[checkpoint].position;
        // iManager.UnFreeze();
        uManager.UnFreeze();
        deathMessage.SetActive(false);
        pauseMenu.SetActive(false);
        dead = false;
        Time.timeScale = 1;
        
    }

    public void EndLevel()
    {
        uManager.Freeze();
        endcutscene.EndScene();
    }

    public void EndLevelScreen()
    {
        endMenuScore.text = "You collected " + beanCount;
        endMenuScreen.SetActive(true);
    }

    public void PlayerDie()
    {
        pAnimator.SetTrigger("dead");
        // iManager.Freeze();
        uManager.Freeze();
        deathMessage.SetActive(true);
        dead = true;
    }

    public void nextCheckpoint()
    {
        checkpoint++;
    }

    public void CollectBean()
    {
        beanCount++;
        Debug.Log("beanCount = " + beanCount);
    }

    public void ReachCoffeeMachine()
    {
        if (beanCount == 3)
        {

        }
        else
        {

        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        // iManager.Freeze();
        uManager.Freeze();
        Time.timeScale = 0;
        paused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        //  iManager.UnFreeze();
        uManager.UnFreeze();
        Time.timeScale = 1;
        paused = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
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
        SceneManager.LoadScene(3);
    }
}
