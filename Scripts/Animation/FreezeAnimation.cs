using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeAnimation : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel = null;
    [SerializeField] private Animator myAnim;

    private void Awake()
    {
        myAnim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            myAnim.Play("freezing anim_0");
            menuPanel.SetActive(true);
        }
    }
}