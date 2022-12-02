using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManoBroController : MonoBehaviour
{
    private Animator myAnim;


    void Awake()
    {
        myAnim = GetComponent<Animator>();
    }

    public void CanSpawn()
    {
        myAnim.SetTrigger("cair");
    }
    
    // called by the animator
    public void ShowDialog()
    {
        UIManager.Instance.ShowManobroPanel();
        TesteAnim.Instance.DestroyWeaponParent();
    }

 
}
