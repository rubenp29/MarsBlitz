using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemyShoot : MonoBehaviour
{
    // Animation Parameters
    private const string animParameterShoot = "Shoot";


    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletDirection;
    [SerializeField] private float timeBtwShoots;

    // Components
    private Animator myAnimator = null;
    private MediumEnemyBehaviour myMediumEnemyBehaviour;
    private MediumLife myMediumEnemyLife;
    private bool shoot = false;

    //Audio Components
    private AudioSource myAudioSource = null;
    [SerializeField] protected AudioClip shootingSound = null;

    // States
    private bool attacking = false;

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
        myMediumEnemyBehaviour = GetComponent<MediumEnemyBehaviour>();
        myAnimator = GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();
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
        while (true)
        {
            myAudioSource.PlayOneShot(shootingSound);
            yield return new WaitForSeconds(timeBtwShoots);
            myAnimator.SetTrigger(animParameterShoot);
            Instantiate(bullet, bulletDirection.position, Quaternion.identity);
        }
    }

    private bool CanShoot()
    {
        if (myMediumEnemyBehaviour)
        {
            return true;
        }

        return !myMediumEnemyLife.IsDead();
    }
}