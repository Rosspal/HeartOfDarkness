using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed = 100.0f;

    private bool start = false;
    private bool twist = false;
    public bool go = false;


    void Update()
    {
        if (go)
        {
            start = true;
        }

        if (start)
        {
            if (twist)
            {
                transform.Rotate(0, speed * Time.deltaTime * -1, 0);
                if (transform.eulerAngles.y < 5)
                {
                    Vector3 temp = new Vector3(0, 0, 0);
                    transform.eulerAngles = temp;
                    twist = false;
                    start = false;
                } 
            }
            else
            {
                transform.Rotate(0, speed * Time.deltaTime, 0);
                if (transform.eulerAngles.y > 180)
                {
                    Vector3 temp = new Vector3(0, -180, 0);
                    transform.eulerAngles = temp;
                    twist = true;
                    start = false;
                }
                
                


            }
        }
    }

    public void Go()
    {
        start = true;
    }
}
