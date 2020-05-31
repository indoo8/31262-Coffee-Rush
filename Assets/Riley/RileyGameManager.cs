using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RileyGameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerStartPos;
    [SerializeField] private GameObject[] respawningObjects;
    [SerializeField] private RisingWater risingWater;
    private Animator pAnimator;
    private RileyInputManager iManager;
    // Start is called before the first frame update
    void Start()
    {
        iManager = gameObject.GetComponent<RileyInputManager>();
        player.transform.position = playerStartPos.position;
        pAnimator = player.GetComponent<Animator>();
        risingWater.ResetWater();
        
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
        risingWater.ResetWater();
    }

    public void PlayerDie()
    {
        pAnimator.SetBool("dead", true);
        iManager.Freeze();
        risingWater.StopWater();
    }

    public void NewCheckpoint()
    {

    }
}
