using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerStartPos;
    [SerializeField] private GameObject[] respawningObjects;
    private InputManager iManager;
    // Start is called before the first frame update
    void Start()
    {
        iManager = gameObject.GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {

        iManager.UnFreeze();
    }

    public void PlayerDie()
    {
        iManager.Freeze();
        Invoke("Respawn", 3f);
    }

    public void NewCheckpoint()
    {

    }
}
