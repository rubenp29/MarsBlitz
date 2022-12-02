using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator myAnim;


    void Awake()
    {
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myAnim.SetTrigger("cair");
        }
    }

    // Callled by the animation
    public void Move()
    {
        PlayerMovement.Instance.CanMove(true);
        UIManager.Instance.CanPause(true);
    }
}