using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkManager : MonoBehaviour
{
    public Animator animator;
    float InputX;
    float InputY;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool moving = false;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SetRunning(true);
            moving = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            SetRunning(true);
            moving = true;
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            SetRunning(true);
            moving = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            SetRunning(true);
            moving = true;
        }

        if (!moving)
        {
            SetRunning(false);
        }
    }

    void SetRunning(bool isRunning)
    {
        if (animator.GetBool("isRunning") != isRunning)
        {
            animator.SetBool("isRunning", isRunning);
        }
    }
}


