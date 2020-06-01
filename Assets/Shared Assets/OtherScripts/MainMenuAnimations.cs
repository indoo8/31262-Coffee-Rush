using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimations : MonoBehaviour
{
    [SerializeField] Animator pAnimator, cmAnimator;

    // Start is called before the first frame update
    void Start()
    {
        pAnimator.SetBool("grounded", true);
        pAnimator.SetFloat("speed", 8f);
        cmAnimator.SetTrigger("fillCoffeeLoop");
    }
}
