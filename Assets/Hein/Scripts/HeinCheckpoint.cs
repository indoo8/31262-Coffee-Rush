using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeinCheckpoint : MonoBehaviour
{
    public GameObject spawn;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            spawn.transform.position = this.transform.position;
        }

    }
}
