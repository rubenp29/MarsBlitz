using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject door2;

    private void Start()
    {
        door.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Artur"))
        {
            door.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Artur"))
        {
            door2.SetActive(true);
            door.SetActive(false);
        }
    }
}