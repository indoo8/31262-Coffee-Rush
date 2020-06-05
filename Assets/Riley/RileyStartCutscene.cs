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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Begin()
    {
        StartCoroutine(StartCutscene());
    }

    IEnumerator StartCutscene()
    {
        iManager.Freeze();
        yield return new WaitForSeconds(2f);
        cTrapdoor.SetActive(false);
        iManager.UnFreeze();
        yield return new WaitForSeconds(5f);
        cTopFloor.SetActive(false);
    }
}
