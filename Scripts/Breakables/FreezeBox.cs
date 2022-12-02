using System;
using System.Security.Cryptography;
using UnityEngine;

public class FreezeBox : MonoBehaviour
{
    private PlayerMovement myPlayerMovement = null;
    private EnemyMovementParent myEnemyLifeMovementParent = null;


    private Transform bulletTransform;

    [SerializeField] private int damage = 0;
    [SerializeField] private float SplashRange = 1f;
    [SerializeField] private float freezeTime = 2f;
    [SerializeField] private Collider2D myCollider;
    [SerializeField] private Collider2D myColliderTriger;
    private Animator myAnimator;

    // //Audio Componenets
    private AudioSource myAudioSource;
    [SerializeField] private AudioClip freezeSound;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        myColliderTriger = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            var hitColliders = Physics2D.OverlapCircleAll(this.transform.position, SplashRange);
            foreach (var hitCollider in hitColliders)
            {
                myEnemyLifeMovementParent = hitCollider.gameObject.GetComponent<EnemyMovementParent>();
                if (myEnemyLifeMovementParent != null)
                {
                    myEnemyLifeMovementParent.Hit(damage, freezeTime);
                }

                myPlayerMovement = hitCollider.gameObject.GetComponent<PlayerMovement>();
                if (myPlayerMovement != null)
                {
                    myPlayerMovement.Hit(damage, freezeTime);
                }
            }

            Break();
        }
    }

    private void Break()
    {
        myAnimator.SetTrigger("show");
        AudioSource.PlayClipAtPoint(freezeSound, transform.position, 0.4f);
        myCollider.enabled = false;
        myColliderTriger.enabled = false;
        Invoke("Destroy", 2f);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}