using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RileyEndCutscene : MonoBehaviour
{
    [SerializeField] private RileyGameManager gManager;
    [SerializeField] private RileyInputManager iManager;
    [SerializeField] private GameObject cBandit, cPlayer, cBanditBean, cPlayerBean, cMachineBean, noEscapeText, goHomeText;
    [SerializeField] private Animator cPAnimator, cCoffeeMachineAnimator;
    [SerializeField] float walkSpeed;
    [SerializeField] Transform cStartPos, cEndPos, cStartPos2, cEndPos2, cPlayerTransform;
    private bool playerWalk1 = false, playerWalk2 = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (playerWalk1)
        {
            cPlayerTransform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
            cPAnimator.SetFloat("speed", walkSpeed);
            if (cPlayerTransform.position.x > cEndPos.position.x)
            {
                playerWalk1 = false;
                cPAnimator.SetFloat("speed", 0);
            }
        }

        if (playerWalk2)
        {
            cPlayerTransform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
            cPAnimator.SetFloat("speed", walkSpeed);
            if (cPlayerTransform.position.x < cEndPos2.position.x)
            {
                playerWalk2 = false;
                cPAnimator.SetFloat("speed", 0);
            }
        }
    }

    public void Begin()
    {
        StartCoroutine(StartEndCutscene());
    }

    IEnumerator StartEndCutscene()
    {
        RemovePlayerComponents();
        iManager.Freeze();
        playerWalk1 = true;
        cPAnimator.SetBool("grounded", true);
        yield return new WaitForSeconds(4f);
        StealBean();
        noEscapeText.SetActive(false);
        goHomeText.SetActive(true);
        yield return new WaitForSeconds(3f);
        GoHome();
        yield return new WaitForSeconds(3f);
        MakeCoffee();
        yield return new WaitForSeconds(3f);
        cPAnimator.SetTrigger("drinkCoffee");
        cPlayer.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(4f);
        gManager.EndLevelScreen();

        
    }

    private void RemovePlayerComponents()
    {
        cPlayer.GetComponent<PlayerMovement>().enabled = false;
        Destroy(cPlayer.GetComponent<Rigidbody2D>());
        cPlayer.GetComponent<CircleCollider2D>().enabled = false;
    }

    private void StealBean()
    {
        cPlayerBean.SetActive(true);
        cBanditBean.SetActive(false);
    }

    private void GoHome()
    {
        cPlayerTransform.position = cStartPos2.position;
        Vector3 scale = cPlayerTransform.localScale;
        scale.x *= -1;
        cPlayerTransform.localScale = scale;
        playerWalk2 = true;
    }

    private void MakeCoffee()
    {
        cPlayerBean.SetActive(false);
        cMachineBean.SetActive(true);
        cCoffeeMachineAnimator.SetTrigger("fillCoffee");
    }
}
