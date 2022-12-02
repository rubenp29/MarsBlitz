using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] private GameObject doors;
    [SerializeField] private GameObject secondDoor;
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();

    [SerializeField] private GameObject mapHider = null;

    private Collider2D myCollider;
    private Collider2D myColliderSecondDoor;

    private Animator myAnimator;
    private Animator myAnimSecondDoor;

    //Variables
    private bool openWhenEnemiesCleared, closeWhenEntered;

    private void Awake()
    {
        myAnimator = doors.GetComponent<Animator>();
        myAnimSecondDoor = secondDoor.GetComponent<Animator>();
        myCollider = doors.GetComponent<Collider2D>();
        myColliderSecondDoor = secondDoor.GetComponent<Collider2D>();
    }

    /*
     * entry - ele fechado
     * close -  anim a fechar
     * open - anim a abrir
     */
    private void Start()
    {
        /*myAnimator.SetTrigger("open");
        myAnimSecondDoor.SetTrigger("open");*/

        if (openWhenEnemiesCleared)
        {
            closeWhenEntered = true;
        }

        myAnimator.SetTrigger("entry");
        myAnimSecondDoor.SetTrigger("entry");

        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }
    }

    private void Update()
    {
        if (enemies.Count > 0)
        {
            for (int i = 0; i < enemies.Count; ++i)
            {
                if (enemies[i] == null)
                {
                    enemies.RemoveAt(i);

                    --i;
                }
            }
        }

        if (enemies.Count == 0)
        {
            OpenDoors();
        }
    }

    private void OpenDoors()
    {
        myAnimSecondDoor.SetTrigger("open");
        myAnimator.SetTrigger("open");
        myCollider.enabled = false;
        myColliderSecondDoor.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Artur") /*&& !other.isTrigger*/)
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.SetActive(true);
            }

            if (enemies.Count > 0)
            {
                myAnimator.SetTrigger("close");
                myAnimSecondDoor.SetTrigger("close");
                mapHider.SetActive(false);
            }
        }
    }
}