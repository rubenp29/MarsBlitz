using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class Box : MonoBehaviour
{
    private Transform bulletTransform;

    private Animator myAnimation;
    [SerializeField] private GameObject healthPickup = null;

    [SerializeField] private int dropChance = 10;
    [SerializeField] private AudioClip breakingSound = null;
    private Collider2D myCollider;

    private void Awake()
    {
        myAnimation = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Break();
        }
    }

    private void Break()
    {
        DropHealth();
        AudioSource.PlayClipAtPoint(breakingSound, transform.position, 0.4f);
        myAnimation.SetTrigger("show");
        myCollider.enabled = false;
        Invoke("Disable",1.5f);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

    private void DropHealth()
    {
        int chance = Random.Range(0, 100);

        if (chance <= dropChance)
        {
            Instantiate(healthPickup, transform.position, transform.rotation);
        }
    }
}