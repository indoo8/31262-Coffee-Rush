using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RileyInputManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement pMove;
    [SerializeField] private RileyGameManager gManager;
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

        if (freeze)
        {
            if (Input.GetButton("Submit"))
            {
                UnFreeze();
                gManager.Respawn();
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
