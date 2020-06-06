using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JakeCutScene : MonoBehaviour
{
    [SerializeField] GameObject BeanBandit, jumpPad, jumpPad2;
    [SerializeField] private JakeInputManager jManager;
    [SerializeField] private JakeGameManager jgManager;
    private Transform cPlayerTransform, BeanBanditTransform;
    private Animator banditAnimator, jumpPadAnim;
    [SerializeField] private float runSpeed, upSpeed;
    private bool banditEscape = false, banditJump = false, stopJump = false, beanRun = false;
    [SerializeField] private Transform bStartPos, bEndPos;

    // Start is called before the first frame update
    void Start()
    {
        jManager.Freeze();

        BeanBanditTransform = BeanBandit.transform;
        Vector3 banditPos = BeanBanditTransform.position;
        banditPos.x = bStartPos.position.x;
        banditAnimator = BeanBandit.GetComponent<Animator>();
        jumpPadAnim = jumpPad.GetComponent<Animator>();

        StartCoroutine(startCutScene());
    }

    // Update is called once per frame
    void Update()
    {
        if (banditEscape)
        {
            BeanBanditTransform.Translate(Vector3.right * runSpeed * Time.deltaTime);
            banditAnimator.SetFloat("speed", runSpeed);
            if(BeanBanditTransform.position.x >= bEndPos.position.x)
            {
                banditEscape = false;
                banditAnimator.SetFloat("speed", 0);
            }
        }
        if (banditJump)
        {
            jumpPadAnim.SetBool("Spring", true);
            StartCoroutine(jumping());

            BeanBanditTransform.Translate(Vector3.up * upSpeed * Time.deltaTime);
        }
        if (beanRun)
        {
            banditJump = false;
            BeanBanditTransform.Translate(Vector3.right * runSpeed * Time.deltaTime);
            banditAnimator.SetFloat("speed", runSpeed);
        }


        if (stopJump)
        {
            jumpPadAnim.SetBool("Spring", false);
        }
    }

    IEnumerator startCutScene()
    {
        yield return new WaitForSeconds(0f);
        banditEscape = true;
        yield return new WaitForSeconds(1f);
        banditJump = true;
        yield return new WaitForSeconds(0.53f);
        beanRun = true;
    }
    IEnumerator jumping()
    {
        yield return new WaitForSeconds(0.15f);
        stopJump = true;
    }
}
