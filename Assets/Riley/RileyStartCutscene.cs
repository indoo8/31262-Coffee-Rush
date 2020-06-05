using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RileyStartCutscene : MonoBehaviour
{
    [SerializeField] private GameObject cBandit, cTrapdoor, cTopFloor;
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

        StartCoroutine(StartCutscene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartCutscene()
    {
        yield return new WaitForSeconds(5f);
    }
}
