using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumppadText : MonoBehaviour
{

    public GameObject text;

    private void Start()
    {
        text.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            text.SetActive(true);
            StartCoroutine("WaitTenSeconds");
        }
    }

    IEnumerator WaitTenSeconds()
    {
        yield return new WaitForSeconds(10);
        Destroy(text);
    }
}
