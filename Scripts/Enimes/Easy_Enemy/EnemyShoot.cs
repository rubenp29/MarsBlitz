using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletDirection;
    [SerializeField] private float timeBtwShoots;

    [SerializeField] private GameObject gun;

    private Animator myShoot;

    // Components
    private Animator myAnimator = null;
    private EnemyBehaviour myEnemyBehaviour;
    private SimpleLife myEnemyLife;
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
        myAnimator = GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();
        myShoot = gun.gameObject.GetComponentInChildren<Animator>();
        myEnemyLife = GetComponent<SimpleLife>();
    }

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    public void EasyShoot()
    {
        attacking = true;
    }

    private IEnumerator Shooting()
    {
        while (true && !PlayerLife.Instance.IsDead() && !myEnemyLife.IsDead())
        {
            yield return new WaitForSeconds(timeBtwShoots);
            attacking = true;
            myAudioSource.PlayOneShot(shootingSound, 0.5f);
            Instantiate(bullet, bulletDirection.position, Quaternion.identity);
            myShoot.SetTrigger("shoot");
            yield return new WaitForSeconds(0.5f);
            attacking = false;
        }

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