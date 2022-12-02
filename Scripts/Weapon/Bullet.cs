using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private AudioSource myAudioSource = null;
    [SerializeField] private float playerBullet = 60f;
    [SerializeField] private float waitTimeBtwShoot = 3f;

    //audioComponents
    [SerializeField] private AudioClip bulletWall = null;

    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyBulletAfterTime());
    }

    IEnumerator DestroyBulletAfterTime()
    {
        yield return new WaitForSeconds(waitTimeBtwShoot);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemies"))
        {
            Life life = other.GetComponent<Life>();
            if (life != null)
            {
                life.TakeDamage(playerBullet);
            }

            DestroyBullet();
        }

        if (other.CompareTag("Walls"))
        {
            AudioSource.PlayClipAtPoint(bulletWall, transform.position, 0.4f);
            Destroy(gameObject);
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}