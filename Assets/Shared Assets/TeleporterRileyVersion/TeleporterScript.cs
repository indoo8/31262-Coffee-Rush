using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScript : MonoBehaviour
{

    [SerializeField] private GameObject linkedTeleporter;
    [SerializeField] private Transform tpPos;
    [SerializeField] private PlayerMovement pMove;
    [SerializeField] private bool  canBeEntered;
    private Animator tAnimator;
    // Start is called before the first frame update
    void Start()
    {
        tAnimator = gameObject.GetComponent<Animator>();
        tAnimator.SetBool("canEnter", canBeEntered);
        if (canBeEntered)
        {
            tpPos = linkedTeleporter.transform;
        }
    }

    public void EnterTeleporter()
    {
        tAnimator.SetTrigger("useTeleporter");
        // tpPos.position;
    }
}
