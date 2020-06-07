using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GavinPlayerCollisions : MonoBehaviour
{
    [SerializeField] private GavinGameManager gManager;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "death")
        {
            
            gManager.PlayerDie();
        }
        if (collision.gameObject.tag == "bean")
        {
            gManager.CollectBean();
            collision.gameObject.SetActive(false);
        }
 //       if (collision.gameObject.tag == "checkpoint")
 //       {
  //          gManager.NextCheckpoint();
   //         collision.gameObject.SetActive(false);
   //     }
    }
}
