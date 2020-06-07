using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JakeEndCutScene : MonoBehaviour
{
    [SerializeField] GameObject player, beanbandit;
    [SerializeField] JakeInputManager iManager;
    [SerializeField] JakeGameManager gManager;
    private Transform banditTransform;
    private Animator banditAnim;
    [SerializeField] private float runSpeed, upSpeed, downSpeed;
    private bool banditCaught = false, banditEscape = false, banditFrighten = false, banditDown = false, grounded = false;
    [SerializeField] private Transform bStart, bEnd;

    // Start is called before the first frame update
    void Start()
    {
        banditAnim = beanbandit.GetComponent<Animator>();
        banditTransform = beanbandit.transform;
        Vector3 banditPos = banditTransform.position;
        banditPos.x = bStart.position.x;
    }
    public void EndScene()
    {
        iManager.Freeze();
        StartCoroutine(banditScene());
    }

    // Update is called once per frame
    void Update()
    {
        if (banditFrighten)
        {
            banditCaught = false;
            banditTransform.Translate(Vector3.up * upSpeed * Time.deltaTime);
        }
        if (banditDown)
        {
            banditFrighten = false;
            banditTransform.Translate(Vector3.down * downSpeed * Time.deltaTime);
        }
        if (banditEscape)
        {
            banditDown = false;
            banditTransform.Translate(Vector3.right * runSpeed * Time.deltaTime);
            banditAnim.SetFloat("speed", runSpeed);
            if (banditTransform.position.x <= bEnd.position.x) {
                beanbandit.SetActive(false);
            }
        }
    }

    IEnumerator banditScene()
    {
        yield return new WaitForSeconds(0.5f);
        flipBandit();
        yield return new WaitForSeconds(0.2f);
        banditFrighten = true;
        yield return new WaitForSeconds(0.2f);
        banditDown = true;
        yield return new WaitForSeconds(0.1f);
        flipBandit();
        yield return new WaitForSeconds(0.1f);
        banditEscape = true;
        yield return new WaitForSeconds(1f);
        gManager.EndLevelScreen();
    }

    private void flipBandit()
    {
        Vector3 scale = banditTransform.localScale;
        scale.x *= -1;
        banditTransform.localScale = scale;
    }
}
