using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEndCutsceneManager : MonoBehaviour
{
    [SerializeField] private GameObject cBandit;
    [SerializeField] private Transform banditStartPos, banditEndPos;
    private Animator bAnimator;
    [SerializeField] private Animator tAnimator;
    private Transform cBanditTransform;
    [SerializeField] private TutorialGameManager gManager;
    [SerializeField] private float runSpeed;
    private bool banditRun = false;
    [SerializeField] GameObject foundText, escapingText, beginningText;
    // Start is called before the first frame update
    void Start()
    {
        //cBanditTransform.position = banditStartPos.transform.position;
        bAnimator = cBandit.GetComponent<Animator>();
        tAnimator.SetBool("canEnter", true);
        cBanditTransform = cBandit.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (banditRun)
        {
            cBanditTransform.Translate(Vector3.left * runSpeed * Time.deltaTime);
            bAnimator.SetFloat("speed", runSpeed);
            /*
            if (cBanditTransform.position.x <= banditEndPos.position.x)
            {
                banditRun = false;
                bAnimator.SetFloat("speed", 0);
         
            }*/

        }
    }

    public void StartEndCutscene()
    {
        Debug.Log("startEndCutscene");
        StartCoroutine(EndCutscene());
    }

    IEnumerator EndCutscene()
    {
        Debug.Log("endCutsceneStarted");
        foundText.SetActive(true);
        yield return new WaitForSeconds(2f);
        foundText.SetActive(false);
        escapingText.SetActive(true);
        banditRun = true;
        yield return new WaitForSeconds(3f);
        escapingText.SetActive(false);
        beginningText.SetActive(true);
        cBandit.SetActive(false);
        yield return new WaitForSeconds(3f);
        gManager.EndLevelScreen();

    }
}
