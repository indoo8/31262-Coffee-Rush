using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JakeGameManager : MonoBehaviour
{
    [SerializeField] private GameObject player, deathMessage, pauseMenu;
    [SerializeField] private Transform playerStartPos;
    [SerializeField] private GameObject[] coffeeBeans;
    [SerializeField] private Animator pAnimator, cmAnimator;
    //private RileyInputManager iManager;
    private JakeInputManager uManager;
    private int beanCount = 0;
    public bool paused = false, dead = false;
    // Start is called before the first frame update
    void Start()
    {
        //  iManager = gameObject.GetComponent<RileyInputManager>();
        uManager = gameObject.GetComponent<JakeInputManager>();
        player.transform.position = playerStartPos.position;
        deathMessage.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
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
        uManager.UnFreeze();
        deathMessage.SetActive(false);
        pauseMenu.SetActive(false);
        dead = false;

        for (int i = 0; i < coffeeBeans.Length; i++)
        {
            coffeeBeans[i].SetActive(true);
        }
    }

    public void PlayerDie()
    {
        pAnimator.SetTrigger("dead");
        // iManager.Freeze();
        uManager.Freeze();
        deathMessage.SetActive(true);
        dead = true;
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
}
