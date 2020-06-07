using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RileyStartCutscene : MonoBehaviour
{
    [SerializeField] private GameObject cBandit, cTrapdoor, cTopFloor, cTrapText, cFoundHimText, cArrows;
    [SerializeField] private RileyGameManager gManager;
    [SerializeField] private RileyInputManager iManager;
    private Animator cBanditAnimator;
    private Transform cBanditTransform;
    [SerializeField] private float banditSpeed;
    private bool banditRun = false;
    [SerializeField] private Transform bStartPos, bEndPos;
    // Start is called before the first frame update
    void Start()
    {
        cBanditAnimator = cBandit.GetComponent<Animator>();
        cBanditTransform = cBandit.transform;
        Vector3 banditpos = cBandit.transform.position;
        banditpos.x = bStartPos.position.x;
        cBanditTransform.position = banditpos;
        banditRun = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (banditRun)
        {
            cBanditTransform.Translate(Vector3.right * banditSpeed * Time.deltaTime);
            cBanditAnimator.SetFloat("speed", banditSpeed);
            if (cBanditTransform.position.x > bEndPos.position.x)
            {
                banditRun = false;
                cBanditAnimator.SetFloat("speed", 0);
                Vector3 scale = cBanditTransform.localScale;
                scale.x *= -1;
                cBanditTransform.localScale = scale;
            }
        }
    }

    public void Begin()
    {
        StartCoroutine(StartCutscene());
    }

    IEnumerator StartCutscene()
    {
        iManager.Freeze();
        cTrapText.SetActive(true);
        yield return new WaitForSeconds(1f);
        cFoundHimText.SetActive(false);
        cTrapdoor.SetActive(false);
        cArrows.SetActive(true);
        iManager.UnFreeze();
        yield return new WaitForSeconds(5f);
        cTrapText.SetActive(false);
        cTopFloor.SetActive(false);
        cTrapdoor.SetActive(true);
    }
}
