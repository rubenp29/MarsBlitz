using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    private const string animParameterDead = "dead";

    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;

    private PlayerMovement player;
    private Animator myAnimator;

    private bool dead = false;

    public bool IsDead()
    {
        return dead;
    }


    public void TakeDamage(GameObject instigator, float damage)
    {
        Debug.Log(damage + " damage taken from " + instigator.name);


        currentHealth -= damage;


        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Dismiss();
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Dismiss()
    {
        Destroy(gameObject);
    }
   
}
