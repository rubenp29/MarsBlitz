using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoomController : MonoBehaviour
{
    [SerializeField] private GameObject doors;
    [SerializeField] private PlayerMovement myPlayer;
    private Collider2D myCollider;
    private Animator myAnimator;

    private void Awake()
    {
        myAnimator = doors.GetComponent<Animator>();
        myCollider = doors.GetComponent<Collider2D>();
    }


    void Update()
    {
        if (myPlayer.PlayerHasGun())
        {
            OpenDoors();
            //Destroy(gameObject);
        }
    }

    private void OpenDoors()
    {
        myAnimator.SetTrigger("entry");
        myCollider.enabled = false;
    }
}