using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JakeCutScene : MonoBehaviour
{
    [SerializeField] GameObject player, fakeplayer, BeanBandit, jumpPad, jumpPad2, fakejumpPad, fakejumpPad2, fakejumpPad3, otherBeanBandit;
    [SerializeField] private JakeInputManager jManager;
    [SerializeField] private JakeGameManager jgManager;
    private Transform BeanBanditTransform;
    private Animator banditAnimator;
    [SerializeField] private float runSpeed;
    private bool banditEscape = false, escapeDone = false;
    [SerializeField] private Transform bStartPos;

    // Start is called before the first frame update
    void Start()
    {
        otherBeanBandit.SetActive(false);
        fakeplayer.SetActive(true);
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
        }
        if (escapeDone)
        {
            banditEscape = false;
            BeanBandit.SetActive(false);
            fakejumpPad.SetActive(false);
            fakejumpPad2.SetActive(false);
            fakejumpPad3.SetActive(false);
            jumpPad.SetActive(true);
            jumpPad2.SetActive(true);
            fakeplayer.SetActive(false);
            player.SetActive(true);
            jManager.UnFreeze();
            otherBeanBandit.SetActive(true);
        }
    }

    IEnumerator startCutScene()
    {
        yield return new WaitForSeconds(0f);
        banditEscape = true;
        yield return new WaitForSeconds(5f);
        escapeDone = true;
    }
}
