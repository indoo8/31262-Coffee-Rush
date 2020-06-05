using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialGameManager : MonoBehaviour
{
    [SerializeField] private GameObject player, deathMessage, pauseMenu, endMenuScreen;
    [SerializeField] private Text endMenuScore, endMenuTotal;
    [SerializeField] private Transform playerStartPos;
    //[SerializeField] private GameObject[] coffeeBeans;
    [SerializeField] private int totalBeans;
    [SerializeField] private Animator pAnimator, cmAnimator;
    [SerializeField] private TutorialEndCutsceneManager endCutscene;
    //private RileyInputManager iManager;
    private TutorialInputManager iManager;
    private int beanCount = 0;
    public bool paused = false, dead = false;
    // Start is called before the first frame update
    void Start()
    {
      //  iManager = gameObject.GetComponent<RileyInputManager>();
        iManager = gameObject.GetComponent<TutorialInputManager>();
        player.transform.position = playerStartPos.position;
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
        player.transform.position = playerStartPos.position;
       // iManager.UnFreeze();
        iManager.UnFreeze();
        deathMessage.SetActive(false);
        pauseMenu.SetActive(false);
        dead = false;

        /*
        for (int i = 0; i < coffeeBeans.Length; i++)
        {
            coffeeBeans[i].SetActive(true);
        }*/
    }

    public void PlayerDie()
    {
        pAnimator.SetTrigger("dead");
       // iManager.Freeze();
        iManager.Freeze();
        deathMessage.SetActive(true);
        dead = true;
    }

    public void CollectBean()
    {
        beanCount++;
        Debug.Log("beanCount = " + beanCount);
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
       // iManager.Freeze();
        iManager.Freeze();
        Time.timeScale = 0;
        paused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
      //  iManager.UnFreeze();
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
        SceneManager.LoadScene(2);
    }
}
