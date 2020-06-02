using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeansCollision : MonoBehaviour
{
    int beanCounter = 0;
    public GameManagerTutorial gManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "death")
        {
            Debug.Log("collided with: " + collision.gameObject.name);
            gManager.PlayerDie();
        }



        if(collision.gameObject.tag == "bean")
        {
            //beanCounter++;
            //Debug.Log(beanCounter);
            //collect bean through manager script?
            gManager.CollectBean();
            collision.gameObject.SetActive(false);
        }
    }

}
