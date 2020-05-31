using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingWater : MonoBehaviour
{
    [SerializeField] private  float speed = 1;
    [SerializeField] private Transform startPos, water;
    private bool rising = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (rising)
        {
            water.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    public void RaiseWater()
    {
        rising = true;
    }

    public void StopWater()
    {
        rising = false;
    }

    public void ResetWater()
    {
        rising = true;
        water.position = startPos.position;
    }
}
