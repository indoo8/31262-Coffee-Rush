using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JakeCutScene : MonoBehaviour
{
    [SerializeField] GameObject BeanBandit, jumpPad, jumpPad2, fakejumpPad, fakejumpPad2, fakejumpPad3;
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
        jumpPad.SetActive(false);
        jumpPad2.SetActive(false);

        BeanBanditTransform = BeanBandit.transform;
        Vector3 banditPos = BeanBanditTransform.position;
        banditPos.x = bStartPos.position.x;
        banditAnimator = BeanBandit.GetComponent<Animator>();

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
    }

    IEnumerator startCutScene()
    {
        yield return new WaitForSeconds(0f);
        banditEscape = true;
    }
}
