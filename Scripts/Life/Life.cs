using UnityEngine;
using UnityEngine.UI;

public abstract class Life : MonoBehaviour
{
    private const string animParameterDead = "death";
    private Animator myAnimator;

    [SerializeField] protected float maxHealth = 100;
    [SerializeField] protected float currentHealth;

    protected bool isAlive = true;
    private bool dead = false;

    [SerializeField] protected Image lifebarImage = null;

    //Audio Components
    private AudioSource myAudioSource = null;
    [SerializeField] protected AudioClip hittingSound = null;
    [SerializeField] protected AudioClip dyingSound = null;


    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        CurrentLife();
    }

    public void CurrentLife()
    {
        if (isAlive)
        {
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
            lifebarImage.fillAmount = currentHealth / maxHealth;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        AudioSource.PlayClipAtPoint(hittingSound, transform.position);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            AudioSource.PlayClipAtPoint(dyingSound, transform.position, 0.4f);
            Dismiss();
        }
    }

    protected abstract void Dismiss();

    
}