using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeinCoffeeMachine : MonoBehaviour
{
    [SerializeField] private HeinGameManager gManager;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        gManager.EndLevelScreen();
    }
}
