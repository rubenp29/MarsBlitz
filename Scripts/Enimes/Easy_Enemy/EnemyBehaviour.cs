using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class EnemyBehaviour : EnemyMovementParent
{
    //Animation Parameters
    private const string animParameterlSpeed = "speed";

    // Components
    private Animator myAnimator = null;
    private EnemyShoot myEnemyShoot = null;
    private Rigidbody2D myBody;

    private SimpleLife myEnemyLife;
    //private GameObject myPlayer;

    [SerializeField] private float speed = 3f;
    [SerializeField] private float stoppingDistance; // distance between enemy and player
    [SerializeField] private float retreatDistance = 0f; // when enemy should back away
   
    private Vector2 newPosition;

    private Vector3 vel;

    //Conditions
    private bool attacking = false;


    private bool canMove;

    public void SetAttacking(bool attacking)
    {
        this.attacking = attacking;
    }

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myEnemyShoot = GetComponent<EnemyShoot>();
        myEnemyLife = GetComponent<SimpleLife>();
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!myEnemyLife.IsDead())
        {
            EnemyMovement();
            EnemyFlip();
        }
    }


    private bool CanMove()
    {
        if (myEnemyShoot == null)
        {
            return true;
        }

        return !myEnemyLife.IsDead() && !myEnemyShoot.IsAttacking();
    }

    private void EnemyMovement()
    {
        if (!myEnemyShoot.IsAttacking() && !Frozen())
        {
            if (Vector2.Distance(transform.position, myPlayer.transform.position) > stoppingDistance)
            {
                var position =
                    Vector2.MoveTowards(this.transform.position, myPlayer.transform.position,
                        speed * Time.deltaTime);

                myBody.MovePosition(position);
                myAnimator.SetFloat(animParameterlSpeed, 1);
            }
            else if (Vector2.Distance(transform.position, myPlayer.transform.position) < stoppingDistance)
            {
                var position = transform.position;
                myBody.MovePosition(position);
                myAnimator.SetFloat(animParameterlSpeed, 0);
            }
        }
        else
        {
            myAnimator.SetFloat(animParameterlSpeed, 0);
        }
    }
}