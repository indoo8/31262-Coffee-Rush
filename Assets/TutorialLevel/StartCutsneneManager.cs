using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutsneneManager : MonoBehaviour
{
    [SerializeField] private GameObject Player, cPlayer, cTableBean, cBanditBeanBag, cBeanBandit, cDoorOpen, cDoorClosed;
    [SerializeField] private TutorialInputManager iManager;
    [SerializeField] private TutorialGameManager gManager;
    [SerializeField] private GameObject morningText, banditArriveText, banditStealText, banditRunText, arrowKeyText;
    private Transform cPlayerTransform, cBanditTransform;
    private Animator cPlayerAnimator, cBanditAnimator;
    [SerializeField] private float walkSpeed, stealSpeed, runSpeed;
    private bool playerWalk = false, banditWalk = false, banditSteal = false, banditRun = false;
    [SerializeField] private Transform pStartWalkPos, pEndWalkPos, bStartWalkPos, bEndWalkPos, bStealPos;

    // Start is called before the first frame update
    void Start()
    {
        iManager.Freeze();

        cPlayerTransform = cPlayer.transform;
        Vector3 playerpos = cPlayerTransform.position;
        playerpos.x = pStartWalkPos.position.x;
        cPlayerTransform.position = playerpos;

        cBanditTransform = cBeanBandit.transform;
        Vector3 banditpos = cBanditTransform.position;
        banditpos.x = bStartWalkPos.position.x;
        cBanditTransform.position = banditpos;
        flipBandit();

        cPlayerAnimator = cPlayer.GetComponent<Animator>();
        cPlayerAnimator.SetBool("grounded", true);
        cBanditAnimator = cBeanBandit.GetComponent<Animator>();

        StartCoroutine(CutsceneMain());
    }

    // Update is called once per frame
    void Update()
    {
        if (playerWalk)
        {
            cPlayerTransform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
            cPlayerAnimator.SetFloat("speed", walkSpeed*2);
            if(cPlayerTransform.position.x >= pEndWalkPos.position.x)
            {
                playerWalk = false;
                cPlayerAnimator.SetFloat("speed", 0);
            }
        }

        if (banditWalk)
        {
            cBanditTransform.Translate(Vector3.left * runSpeed * Time.deltaTime);
            cBanditAnimator.SetFloat("speed", runSpeed);
            if (cBanditTransform.position.x <= cDoorClosed.transform.position.x){
                OpenDoor();
            }
            if (cBanditTransform.position.x <= bEndWalkPos.position.x)
            {
                banditWalk = false;
                cBanditAnimator.SetFloat("speed", 0);
            }
        }

        if (banditSteal)
        {
            cBanditTransform.Translate(Vector3.left * stealSpeed * Time.deltaTime);
            cBanditAnimator.SetFloat("speed", stealSpeed);
            if (cBanditTransform.position.x <= bEndWalkPos.position.x)
            {
                banditSteal = false;
                StealBeanBag();
                cBanditAnimator.SetFloat("speed", 0);
            }
        }

        if (banditRun)
        {
            cBanditTransform.Translate(Vector3.right * runSpeed * Time.deltaTime);
            cBanditAnimator.SetFloat("speed", runSpeed);
        }
    }

    IEnumerator CutsceneMain()
    {
        yield return new WaitForSeconds(1f);
        playerWalk = true;
        yield return new WaitForSeconds(2f);
        banditWalk = true;
        yield return new WaitForSeconds(4f);
        banditSteal = true;
        yield return new WaitForSeconds(2f);
        flipBandit();
        banditRun = true;
        yield return new WaitForSeconds(2f);
        banditArriveText.SetActive(false);
        banditStealText.SetActive(false);
        banditRunText.SetActive(true);
        arrowKeyText.SetActive(true);
        StartGame();
    }

    private void StartGame()
    {
        iManager.UnFreeze();
        cPlayer.SetActive(false);
        Player.SetActive(true);
        cBeanBandit.SetActive(false);
    }

    private void StealBeanBag()
    {
        cTableBean.SetActive(false);
        cBanditBeanBag.SetActive(true);
        banditStealText.SetActive(true);
    }

    private void OpenDoor()
    {
        cDoorClosed.SetActive(false);
        cDoorOpen.SetActive(true);
        morningText.SetActive(false);
        banditArriveText.SetActive(true);
    }

    private void flipBandit()
    {
        Vector3 scale = cBanditTransform.localScale;
        scale.x *= -1;
        cBanditTransform.localScale = scale;
    }
}
