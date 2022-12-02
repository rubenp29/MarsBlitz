using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileCollision : MonoBehaviour
{
    [SerializeField] private float damage = 10;

    // Cached References.
    private PoolHandler myPoolHandler;

    private Life enemyLife;

    //audioComponents
    private AudioSource myAudioSource = null;
    [SerializeField] private AudioClip bulletWall = null;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
        myPoolHandler = GetComponent<PoolHandler>();
        enemyLife = GetComponent<Life>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Walls"))
        {
            AudioSource.PlayClipAtPoint(bulletWall, transform.position,0.2f);
            myPoolHandler.DismissSelf();
        }
        else if (other.CompareTag("Enemies"))
        {
            if (enemyLife != null)
            {
                enemyLife.TakeDamage(damage);
            }

            myPoolHandler.DismissSelf();
        }
       
        
    }

    private void OnBecameInvisible()
    {
        myPoolHandler.DismissSelf();
    }
}