using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemyBullet : MonoBehaviour
{
    [SerializeField] private float playerBullet = 60f;
    [SerializeField] private float waitTimeBtwShoot = 3f;
    [SerializeField] private float speed = 25f;
    [SerializeField] private float timeBtwShots = 1f;
    [SerializeField] private float tripleChance;
    [SerializeField] private float startTimeBtwShoots;
    
    [SerializeField] private float damage = 10f;

    private Transform player;

    private Vector2 target;

    void Start()
    {
        timeBtwShots = timeBtwShots;
        player = GameObject.FindGameObjectWithTag("Artur").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    private void OnEnable()
    {
        StartCoroutine(DestroyBulletAfterTime());
    }

    IEnumerator DestroyBulletAfterTime()
    {
        yield return new WaitForSeconds(waitTimeBtwShoot);
        Destroy(gameObject);
    }

    private void Update()
    {
        TripleShoot();
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyBullet();
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Artur"))
        {
            PlayerLife life = collider.GetComponent<PlayerLife>();

            if (life != null)
            {
                life.TakeLifeDamage(damage);
            }

            DestroyBullet();
        }

        if (collider.CompareTag("Walls"))
        {
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void TripleShoot()
    {
        int chance = Random.Range(0, 100);

        if (chance <= tripleChance)
        {
            timeBtwShots = startTimeBtwShoots;
        }
    }
}