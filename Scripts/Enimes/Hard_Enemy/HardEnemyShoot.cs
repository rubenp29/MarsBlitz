using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemyShoot : MonoBehaviour
{
    // Animation Parameters
    private const string animParameterShoot = "shoot";


    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform enemyGun;
    [SerializeField] private float timeBtwShoots = 2f;

    // Components
    private Animator myAnimator = null;
    private HardEnemyBehaviour myHardEnemyBehaviour;
    private SimpleLife myHardEnemyLife;
    private bool shoot = false;

    [SerializeField] private GameObject gun;

    private Animator myshoot;

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
        myHardEnemyBehaviour = GetComponent<HardEnemyBehaviour>();
        myAnimator = GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();
        myshoot = gun.gameObject.GetComponentInChildren<Animator>();
        myHardEnemyLife = GetComponent<SimpleLife>();
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
        while (true && !myHardEnemyLife.IsDead())
        {
            attacking = true;

            yield return new WaitForSeconds(timeBtwShoots);
            myshoot.SetTrigger(animParameterShoot);
            Instantiate(bullet, enemyGun.position, Quaternion.identity);
            attacking = false;
        }
    }

    private bool CanShoot()
    {
        if (myHardEnemyBehaviour)
        {
            return true;
        }

        return !myHardEnemyLife.IsDead();
    }
}