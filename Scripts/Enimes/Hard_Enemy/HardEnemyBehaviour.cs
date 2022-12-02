using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class HardEnemyBehaviour : EnemyMovementParent
{
    private const string animParameterlSpeed = "speed";
    private Animator myAnimator = null;
    private HardEnemyShoot myHardEnemyShoot;
   

    // Movement Components
    
    // [SerializeField] private float speed;
    [SerializeField] private float waitTime;
    [SerializeField] private float startWaitTime;
    [SerializeField] private float distance = 2f; // distance of the "radar" (raycast)
    [SerializeField] private float steps = 10f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
    private Vector2 movementTarget;
    private Vector2 movement;

    private Rigidbody2D myBody;
    [SerializeField] private Transform[] wallVectorsDetection;
    [SerializeField] private LayerMask wallLayerMask;
    private RaycastHit2D[] hit = new RaycastHit2D[1];

    //Conditions
    private bool attacking = false;


    public void SetAttacking(bool attacking)
    {
        this.attacking = attacking;
    }


    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myHardEnemyShoot = GetComponent<HardEnemyShoot>();
        myBody = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        waitTime = startWaitTime;
        CalculateNewMovementVector();
        EnemyFlip();
    }

    private void CalculateNewMovementVector()
    {
        // movementPerSecond = movementDirection * speed ;
        movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f).normalized;
        movementTarget = new Vector2(transform.position.x + movementDirection.x * distance,
            transform.position.y + movementDirection.y * distance);
    }


    private void FixedUpdate()

    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, movementDirection, distance, wallLayerMask);


        if (!Frozen() /*&& !myHardlife.IsDead()*/ && !PlayerLife.Instance.IsDead())
        {
            if (!hit)
            {
                transform.position = new Vector2(
                    transform.position.x + (movementTarget.x - transform.position.x) / steps,
                    transform.position.y + (movementTarget.y - transform.position.y) / steps);
            }
            else
            {
                CalculateNewMovementVector();
            }

            if (Vector2.Distance(this.transform.position, movementTarget) < (1 / steps))
            {
                if (waitTime <= 0)
                {
                    CalculateNewMovementVector();
                    waitTime = startWaitTime;
                    myAnimator.SetFloat(animParameterlSpeed, 1);
                }
                else
                {
                    myAnimator.SetFloat(animParameterlSpeed, 0);
                    waitTime -= Time.fixedDeltaTime;
                }
            }
        }
        else if (Frozen())
        {
            myAnimator.SetFloat(animParameterlSpeed, 0);
        }

        if (PlayerLife.Instance.IsDead())
        {
            myAnimator.SetFloat(animParameterlSpeed, 0);
        }
    }
}