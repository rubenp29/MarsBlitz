using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemyLife : MonoBehaviour
{
    [SerializeField] private float maxhealth = 100f;

    //Cached References
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    //Instance variables
    private float health;
    private bool dead = false;

    public bool IsDead()
    {
        return dead;
    }


    private void Awake()
    {
        health = maxhealth;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Is called by the player bullet
    public void TakeDamage(float playerBullet)
    {
        health -= playerBullet;

        CheckDeath();
    }


    private void CheckDeath()
    {
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    private void Die()
    {
        myRigidbody.velocity = Vector2.zero;
        Destroy(gameObject);
    }
}