using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterPanel : MonoBehaviour
{
    private Animator myAnimation;
    void Start()
    {
        myAnimation = GetComponentInChildren<Animator>();
    }

    public void PlayAnimation()
    {
        myAnimation.SetTrigger("panel");
    }
}
