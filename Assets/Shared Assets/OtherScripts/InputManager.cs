using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement pMove;
    [SerializeField] private GameManager gManager;
    private bool freeze = false;

    // Update is called once per frame
    void Update()
    {
        if (!freeze)
        {
            //move left or right
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                pMove.Move();
            }

            //jumping
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
            {
                pMove.Jump();
            }

            //falling down
            if (Input.GetKey(KeyCode.DownArrow))
            {
                pMove.Fall();
            }

        }
    }

    public void Freeze()
    {
        freeze = true;
    }
    public void UnFreeze()
    {
        freeze = false;
    }
}
