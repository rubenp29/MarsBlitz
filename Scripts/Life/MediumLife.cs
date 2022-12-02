using System;
using UnityEngine;

public class MediumLife : Life
{
    private const string animParameterDead = "death";
    private Animator myAnimator;

    private bool dead = false;

    public bool IsDead()
    {
        return dead;
    }

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        CurrentLife();
    }


    protected override void Dismiss()
    {
        dead = true;
        myAnimator.SetTrigger(animParameterDead);
    }

    private void Disable()
    {
        Destroy(gameObject);
    }
}