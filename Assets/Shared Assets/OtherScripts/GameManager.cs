using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] checkpoints;
    [SerializeField] private GameObject[] levelObjects;
    [SerializeField] private GameObject currentCheckpoint;
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

    public void NewCheckpoint()
    {

    }
}
