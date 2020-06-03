using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JakeInputManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement pMove;
    [SerializeField] private JakeGameManager gManager;
    private bool freeze = false;

    // Update is called once per frame
    void Update()
    {
        if (!freeze)
        {
            //move left or right (arrows and a/d)
            if (Input.GetButton("Horizontal"))
            {
                pMove.Move();
            }

            //jumping (space and up arrow)
            if (Input.GetButtonDown("Jump"))
            {
                pMove.Jump();
            }

        }

        if (gManager.dead)
        {
            if (Input.GetButtonDown("Submit") || Input.GetButtonDown("Cancel"))
            {
                UnFreeze();
                gManager.Respawn();
            }
        }

        else if (Input.GetButtonDown("Cancel"))
        {
            if (gManager.paused)
            {
                gManager.ResumeGame();
            }
            else
            {
                gManager.PauseGame();
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
