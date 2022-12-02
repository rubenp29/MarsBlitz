using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemyBehaviour : EnemyMovementParent
{
    private const string animParameterlSpeed = "speed";

    //Components
    private Animator myAnimator = null;
    private TripleShoot myMediumEnemyShoot;
    private MediumLife myMediumEnemyLife;


    [SerializeField] public Transform[] waypoints;
    [SerializeField] private float moveSpeed = 2f;

    int waypointIndex = 0;

    private Rigidbody2D myBody;

    //Conditions
    private bool attacking = false;


    public void SetAttacking(bool attacking)
    {
        this.attacking = attacking;
    }

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myMediumEnemyShoot = GetComponent<TripleShoot>();
        myMediumEnemyLife = GetComponent<MediumLife>();
        myBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Update()
    {
        if (!myMediumEnemyLife.IsDead())
        {
            Move();
            EnemyFlip();
        }
    }

    private bool CanMove()
    {
        if (myMediumEnemyShoot == null)
        {
            return true;
        }

        return !myMediumEnemyLife.IsDead() && !myMediumEnemyShoot.IsAttacking();
    }

    private void Move()
    {
        if (!myMediumEnemyShoot.IsAttacking() && !Frozen() && !PlayerLife.Instance.IsDead())
        {
            var position = transform.position = Vector3.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);

            myBody.MovePosition(position);
            myAnimator.SetFloat(animParameterlSpeed, 1);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }

            if (waypointIndex == waypoints.Length)
                waypointIndex = 0;
        }
        else if (Frozen())
        {
            myAnimator.SetFloat(animParameterlSpeed, 0);
        }
    }
}