using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoomChange : MonoBehaviour
{
    [SerializeField] private GameObject virtualCam;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Artur") && !other.isTrigger)
        {
            virtualCam.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Artur") && !other.isTrigger)
        {
            virtualCam.SetActive(false);
        }
    }
}