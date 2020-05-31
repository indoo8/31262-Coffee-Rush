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
            if (Input.GetButton("Horizontal"))
            {
                pMove.Move();
            }

            //jumping
            if (Input.GetButtonDown("Jump"))
            {
                pMove.Jump();
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
