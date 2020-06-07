using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeinStartCutscene : MonoBehaviour
{
    [SerializeField] private GameObject cBandit;
    private Animator cBanditAnimator;
    private Transform cBanditTransform;
    [SerializeField] private float banditSpeed;
    private bool banditRun = false;

    void Start()
    {
        cBanditAnimator = cBandit.GetComponent<Animator>();
        cBanditTransform = cBandit.transform;
    }

    void Update()
    {
        if (banditRun)
        {
            BanditRun();
        }
    }

    public void BanditRun()
    {
        cBanditTransform.Translate(Vector3.right * banditSpeed * Time.deltaTime);
        cBanditAnimator.SetFloat("speed", banditSpeed);
    }
    

    IEnumerator StartCutscene()
    {
        yield return new WaitForSeconds(5f);
        Destroy(cBandit);
        banditRun = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("collied with animation box");
            banditRun = true;
            StartCoroutine(StartCutscene());
        }
    }
}
