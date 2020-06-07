using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeansCollision : MonoBehaviour
{
    public GameObject jumpPad, wall, jump2, breakWall, sign;

    //int beanCounter = 0;
    public JakeGameManager gManager;

    // Start is called before the first frame update
    void Start()
    {
        jumpPad.SetActive(false);
        sign.SetActive(true);
        jump2.SetActive(false);
        breakWall.SetActive(true);
        wall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "death")
        {
            Debug.Log("collided with: " + collision.gameObject.name);
            gManager.PlayerDie();
        }

        if(collision.gameObject.tag == "bean")
        {
            gManager.CollectBean();
            collision.gameObject.SetActive(false);
        }

        if(collision.gameObject.tag == "checkpoint")
        {
            gManager.nextCheckpoint();
            collision.gameObject.SetActive(false);
        }

        if(collision.gameObject.tag == "superJump")
        {
            jumpPad.SetActive(true);
        }

        if(collision.gameObject.tag == "newArea")
        {
            wall.SetActive(true);
            jump2.SetActive(true);
        }
        
        if(collision.gameObject.tag == "wallBreak")
        {
            breakWall.SetActive(false);
            sign.SetActive(false);
        }

        if(collision.gameObject.tag == "endLevel")
        {
            gManager.EndLevel();
        }
    }

}
