using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTutorial : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerStartPos;
    [SerializeField] private GameObject[] respawningObjects;
    private Animator pAnimator;
    private InputManager iManager;
    // Start is called before the first frame update
    void Start()
    {
        iManager = gameObject.GetComponent<InputManager>();
        player.transform.position = playerStartPos.position;
        pAnimator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        pAnimator.SetBool("dead", false);
        player.transform.position = playerStartPos.position;
        iManager.UnFreeze();
    }

    public void PlayerDie()
    {
        pAnimator.SetBool("dead", true);
        iManager.Freeze();
    }

    public void NewCheckpoint()
    {

    }
}
