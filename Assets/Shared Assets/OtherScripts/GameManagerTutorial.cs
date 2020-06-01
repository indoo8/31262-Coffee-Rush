using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerTutorial : MonoBehaviour
{
    [SerializeField] private GameObject player, deathMessage, pauseMenu;
    [SerializeField] private Transform playerStartPos;
    [SerializeField] private GameObject[] coffeeBeans;
    [SerializeField] private Animator pAnimator, cmAnimator;
    private RileyInputManager iManager;
    private int beanCount = 0;
    public bool paused = false, dead = false;
    // Start is called before the first frame update
    void Start()
    {
        iManager = gameObject.GetComponent<RileyInputManager>();
        player.transform.position = playerStartPos.position;
        deathMessage.SetActive(false);
        pauseMenu.SetActive(false);

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
        dead = false;

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
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();

    }
}
