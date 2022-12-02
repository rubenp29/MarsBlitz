using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int healthToReceive = 10;
    [SerializeField] private AudioClip healthDrop = null;
    private AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Artur"))
        {
            myAudioSource.PlayOneShot(healthDrop);
            PlayerLife.Instance.ReceiveHealth(healthToReceive);
            gameObject.SetActive(false);
        }
    }
}