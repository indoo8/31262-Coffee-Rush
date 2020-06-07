using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeinEndLevel : MonoBehaviour
{
    [SerializeField] private HeinGameManager gManager;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Time.timeScale = 0;
        gManager.EndLevelScreen();
    }
}
