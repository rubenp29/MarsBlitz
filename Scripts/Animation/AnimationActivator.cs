using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationActivator : MonoBehaviour
{
    private Animator myAnim;
    [SerializeField] private GameObject controls;


    void Awake()
    {
        myAnim = GetComponent<Animator>();
    }

// Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myAnim.SetTrigger("break");

            Destroy(controls);
        }
    }
}