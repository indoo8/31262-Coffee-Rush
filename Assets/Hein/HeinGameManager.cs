﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeinGameManager : MonoBehaviour
{
    [SerializeField] private GameObject player, deathMessage, pauseMenu;
    [SerializeField] private Transform playerStartPos;
    [SerializeField] private GameObject[] coffeeBeans;
    [SerializeField] private RisingWater risingWater;
    [SerializeField] private Animator pAnimator, cmAnimator;
    private HeinInputManager iManager;
    private int beanCount = 0;
    public bool paused = false, dead = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started");
        iManager = gameObject.GetComponent<HeinInputManager>();
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
        Debug.Log("Respawned");
        pAnimator.SetTrigger("respawn");
        player.transform.position = playerStartPos.position;
        iManager.UnFreeze();
        deathMessage.SetActive(false);
        pauseMenu.SetActive(false);
        dead = false;
        Time.timeScale = 1;
        for (int i=0; i<coffeeBeans.Length; i++)
        {
            coffeeBeans[i].SetActive(true);
        }
    }

    public void PlayerDie()
    {
        Debug.Log("Died");
        pAnimator.SetTrigger("dead");
        iManager.Freeze();
        deathMessage.SetActive(true);
        dead = true;
    }

    public void CollectBean()
    {
        Debug.Log("Collected Bean");
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
