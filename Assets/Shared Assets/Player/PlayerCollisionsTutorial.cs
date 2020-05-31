using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionsTutorial : MonoBehaviour
{
    public GameManagerTutorial gManager;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "death")
        {
            Debug.Log("collided with " + collision.gameObject.name);
            gManager.PlayerDie();
        }
    }
}
