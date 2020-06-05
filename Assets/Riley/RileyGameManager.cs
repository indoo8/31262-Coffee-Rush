using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RileyGameManager : MonoBehaviour
{
    [SerializeField] private GameObject player, deathMessage, pauseMenu, endMenuScreen;
    [SerializeField] private Text endMenuScore, endMenuTotal;
    [SerializeField] private Transform[] checkpoints;
    [SerializeField] private int totalBeans;
    [SerializeField] private RisingWater risingWater;
    [SerializeField] private Animator pAnimator, cmAnimator;
    [SerializeField] private RileyStartCutscene startCutscene;
    private RileyInputManager iManager;
    private int beanCount = 0, checkpoint = 0;
    public bool paused = false, dead = false;
    // Start is called before the first frame update
    void Start()
    {
        iManager = gameObject.GetComponent<RileyInputManager>();
        player.transform.position = checkpoints[0].position;
        risingWater.ResetWater(checkpoint);
        //risingWater.RaiseWater();
        deathMessage.SetActive(false);
        pauseMenu.SetActive(false);
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
        player.transform.position = checkpoints[checkpoint].position;
        iManager.UnFreeze();
        risingWater.ResetWater(checkpoint);
        if (checkpoint > 1)
            risingWater.RaiseWater();
        deathMessage.SetActive(false);
        pauseMenu.SetActive(false);
        dead = false;
        Time.timeScale = 1;
    }

    public void NextCheckpoint()
    {
        if (checkpoint == 0)
        {
            BeginCutscene();
        }
        checkpoint++;
        Debug.Log(checkpoint);
    }

    public void PlayerDie()
    {
        pAnimator.SetTrigger("dead");
        iManager.Freeze();
        risingWater.StopWater();
        deathMessage.SetActive(true);
        dead = true;
    }

    public void CollectBean()
    {
        beanCount++;
       // Debug.Log("beanCount = " + beanCount);
    }

    public void ToggleWater()
    {
        //Debug.Log("startRaiseWater");
        risingWater.ToggleWater();
    }

    public void BeginCutscene()
    {
        startCutscene.Begin();
    }

    public void EndLevel()
    {

    }

    public void EndLevelScreen()
    {

    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        risingWater.StopWater();
        iManager.Freeze();
        Time.timeScale = 0;
        paused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        risingWater.RaiseWater();
        iManager.UnFreeze();
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
        SceneManager.LoadScene(0);
    }
}
