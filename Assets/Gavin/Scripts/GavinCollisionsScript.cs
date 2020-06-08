using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GavinCollisionsScript : MonoBehaviour
{
    public GavinGameManager gManager;

 
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "death")
        {
           // Debug.Log("collided with " + collision.gameObject.name);
            gManager.PlayerDie();
        }
        if (collision.gameObject.tag == "bean")
        {
            gManager.CollectBean();
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "endLevel")
        {
          //  Debug.Log("endLevelTrigger");
            gManager.EndLevelScreen();
        }
        
    }
}