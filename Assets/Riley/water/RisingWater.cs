using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingWater : MonoBehaviour
{
    [SerializeField] private  float speed = 1;
    [SerializeField] private Transform water;
    [SerializeField] private Transform[] checkpoints;
    private bool rising;
    // Start is called before the first frame update
    void Start()
    {
        checkpoints[0].position = water.position;
        rising = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("waterUpdate");
        if (rising)
        {
           // Debug.Log("moveUp");
            water.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    public void RaiseWater()
    {
        //Debug.Log("rising = true");
        rising = true;
    }

    public void StopWater()
    {
        rising = false;
    }

    public void ResetWater(int index)
    {
        rising = false;
        water.position = checkpoints[index-1].position;
    }

    public void ToggleWater()
    {
        rising = !rising;
    }
}
