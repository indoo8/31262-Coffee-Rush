using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerMovement pMove;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //pMove.Move(-1);
            pMove.Move(Vector2.left);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //pMove.Move(1);
            pMove.Move(Vector2.right);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            pMove.Jump();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            pMove.Fall();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pMove.Jump();
        }

    }
}
