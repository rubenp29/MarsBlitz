using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TripleShoot : MonoBehaviour
{
    // Animation Parameters
    private const string animParameterShoot = "shoot";
    private const string animParameterTripleShoot = "charge";

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletDirection;
    [SerializeField] private float tripleShoots = 20f;
    [SerializeField] private float timeBtwShoots;
    [SerializeField] private float timeBtwTripleShoots;
    private int change;
    private Animator myShoot;

    [SerializeField] private float time = 0.2f;

    [SerializeField] private GameObject gun;

    // Components
    private Animator myAnimator = null;
    private MediumEnemyBehaviour myEnemyBehaviour;
    private MediumLife myEnemyLife;
    private SimpleLife mySimpleLife;
    private bool shoot = false;

    // States
    private bool attacking = false;

    //Audio Components
    private AudioSource myAudioSource = null;
    [SerializeField] protected AudioClip shootingSound = null;

    public bool IsAttacking()
    {
        return attacking;
    }

    public void SetAttacking(bool attacking)
    {
        this.attacking = attacking;
    }

    private void Awake()
    {
        //myEnemyBehaviour = GetComponent<MediumEnemyBehaviour>();
        myAnimator = GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();
        myShoot = gun.gameObject.GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private void Shoot()
    {
        attacking = true;
    }


    private IEnumerator Shooting()
    {
        while (true && attacking != true /*&& !myEnemyLife.IsDead() *//*|| !mySimpleLife.IsDead()*/ &&
               !PlayerLife.Instance.IsDead())
        {
            change = Random.Range(0, 100);


            yield return new WaitForSeconds(timeBtwShoots);
            attacking = true;
            if (change >= tripleShoots)
            {
                myAudioSource.PlayOneShot(shootingSound);
                myShoot.SetTrigger(animParameterShoot);
                yield return new WaitForSeconds(0.5f);
            }
            else if (change <= tripleShoots)
            {
                myShoot.SetTrigger(animParameterTripleShoot);
                yield return new WaitForSeconds(time);

                myShoot.SetTrigger(animParameterShoot);
                yield return new WaitForSeconds(timeBtwTripleShoots);

                myShoot.SetTrigger(animParameterShoot);
                yield return new WaitForSeconds(timeBtwTripleShoots);
            }

            attacking = false;
        }
    }

    public void Tripleshoot()
    {
        myAudioSource.PlayOneShot(shootingSound);
        Instantiate(bullet, bulletDirection.position, Quaternion.identity);
    }


    private bool CanShoot()
    {
        if (myEnemyBehaviour)
        {
            return true;
        }

        return !myEnemyLife.IsDead();
    }
}