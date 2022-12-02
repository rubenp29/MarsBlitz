using UnityEngine;

public abstract class EnemyMovementParent : MonoBehaviour
{
    [SerializeField] private CanvasFlipBar myCanvasFlip = null;
    [SerializeField] protected GameObject myPlayer;
    [SerializeField] protected GameObject iceSprite;
    private bool isFrozen = false;
    private float freezeTimer = 0;


    public bool Frozen()
    {
        return isFrozen;
    }

    public void Hit(int damage, float freezTime)
    {
        Freeze();
        freezeTimer = freezTime;
    }

    public void EnemyFlip()
    {
        if (myPlayer.transform.position.x > transform.position.x)
        {
            //face right
            transform.rotation = Quaternion.Euler(0, 0, 0);
            myCanvasFlip.RestoreRotation();
        }
        else if (myPlayer.transform.position.x < transform.position.x)
        {
            //face left
            myCanvasFlip.RestoreRotation();
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
    }

    private void Update()
    {
        EnemyFlip();
    }

    public void Freeze()
    {
        isFrozen = true;
    }

    private void FixedUpdate()
    {
        if (isFrozen = true && freezeTimer > 0)
        {
            freezeTimer -= Time.deltaTime;
            isFrozen = true;
            iceSprite.SetActive(true);
        }
        else
        {
            iceSprite.SetActive(false);
            isFrozen = false;
        }
    }
}