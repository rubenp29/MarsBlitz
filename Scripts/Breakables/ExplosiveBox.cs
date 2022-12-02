using System.Diagnostics.SymbolStore;
using UnityEngine;

public class ExplosiveBox : MonoBehaviour
{
    private Animator myAnimator = null;
    private PlayerLife myPlayerLife = null;
    private Life myEnemyLife = null;
    private Transform bulletTransform;

    [SerializeField] private float damage = 1;
    [SerializeField] private float splashRange = 1;
    [SerializeField] private float cameraIntensity;
    [SerializeField] private float cameraTime;
    [SerializeField] private Collider2D myCollider2D;
    [SerializeField] private Collider2D myCollider2DTrigger;

    private bool hasExploded = false;

    public bool Explosion()
    {
        return hasExploded;
    }

    // //Audio Componenets
    private AudioSource myAudioSource;
    [SerializeField] private AudioClip explosionSound;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();
        myCollider2DTrigger = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            hasExploded = true;
            var hitColliders = Physics2D.OverlapCircleAll(this.transform.position, splashRange);
            foreach (var hitCollider in hitColliders)
            {
                myEnemyLife = hitCollider.gameObject.GetComponent<Life>();
                if (myEnemyLife != null)
                {
                    myEnemyLife.TakeDamage(damage);
                }

                myPlayerLife = hitCollider.gameObject.GetComponent<PlayerLife>();
                if (myPlayerLife != null)
                {
                    myPlayerLife.TakeLifeDamage(damage);
                }
            }
            
            
            Break();
        }
    }

    private void Break()
    {
        CameraShakes.Instance.ShakeCamera(cameraIntensity, cameraTime);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position, 0.4f);
        myAnimator.SetTrigger("explode");
        myCollider2D.enabled = false;
        myCollider2DTrigger.enabled = false;
        Invoke("Disable",1.5f);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}