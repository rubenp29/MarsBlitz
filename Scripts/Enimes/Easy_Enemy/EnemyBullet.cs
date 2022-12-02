using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed ;
    [SerializeField] private float damage = 10f;
    
    private Transform player;
    private Vector2 target;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Artur").transform;
        target = new Vector2(player.position.x, player.position.y);
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyBullet();
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Artur"))
        {
           PlayerLife.Instance.TakeLifeDamage(damage);
           DestroyBullet();
        }

        if (other.CompareTag("Walls"))
        {
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}