using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomControllerFinalDoor : MonoBehaviour
{
    
    public static RoomControllerFinalDoor Instance { get; private set; }
    [SerializeField] private GameObject doors;
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private GameObject mapHider = null;

    private Collider2D myCollider2D;
    //Variables
    private bool openWhenEnemiesCleared, closeWhenEntered;


    private void Awake()
    {
        Instance = this;
        myCollider2D = GetComponent<Collider2D>();
    }

    private void Start()
    {
        doors.SetActive(false);
        if (openWhenEnemiesCleared)
        {
            closeWhenEntered = true;
        }

        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }
    }

    private void Update()
    {
        if (enemies.Count > 0)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] == null)
                {
                    enemies.RemoveAt(i);

                    i--;
                }
            }

            if (enemies.Count == 0)
            {
                OpenDoors();
            }
        }
    }

    public int GetEnemiesCount()
    {
        return enemies.Count;
    }
    private void OpenDoors()
    {
        doors.SetActive(true);

        closeWhenEntered = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Artur") && !other.isTrigger)
        {
            doors.SetActive(true);
            mapHider.SetActive(false);

            foreach (GameObject enemy in enemies)
            {
                enemy.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        myCollider2D.enabled = false;
    }
}