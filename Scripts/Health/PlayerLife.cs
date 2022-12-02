using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife Instance { get; private set; } = null;

    private const string AnimParameterDead = "dead";

    [Space] [Header("Life Components")] [SerializeField]
    private float maxhealth = 70f;

    // UI elements
    [SerializeField] private Image lifeBarImage = null;
    [SerializeField] private Color invincibilityColor;

    [SerializeField] private float invincibilityDurationSeconds;

    [SerializeField] private float invincibilityDeltaTime;

    //Cached References
    private SpriteRenderer mySpriteRenderer;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    //Audio Components
    [SerializeField] private AudioClip dyingSound = null;

    //Instance variables
    private float health;
    private bool hasMaxHealth = true;
    private bool isInvincible;
    private bool isFrozen;
    private bool hasLife = true;
    private bool isDead = false;

    //called by the animator
    public void ShowDeathScreen()
    {
        GameManager.Instance.ShowDeathPanel();
    }

    public bool IsDead()
    {
        return isDead;
    }

    public bool CanRecive()
    {
        return hasLife;
    }

    public void HasLife()
    {
        maxhealth = 100f;
        UpdateLifeBar();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        health = maxhealth;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

        UpdateLifeBar();
        
    }


    // Is called by the enemie bullet
    public void TakeLifeDamage(float damage)
    {
        if (!isInvincible)
        {
            health -= damage;

            UpdateLifeBar();
            CheckDeath();

            StartCoroutine(BecomeTemporarilyInvincible());
        }
    }

    public void Frezze()
    {
        isFrozen = true;
    }

    // Is called by the health pickup
    public void ReceiveHealth(float healthToReceive)
    {
        health += healthToReceive;

        if (health > maxhealth)
        {
            health = maxhealth;
        }

        UpdateLifeBar();
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        isInvincible = true;

        setAlpha(0.5f);

        yield return new WaitForSeconds(invincibilityDurationSeconds);

        setAlpha(1f);

        isInvincible = false;
    }

    private void setAlpha(float alpha)
    {
        SpriteRenderer[] myChildren = GetComponentsInChildren<SpriteRenderer>();
        Color newColor;
        foreach (SpriteRenderer child in myChildren)
        {
            newColor = child.color;
            newColor.a = alpha;
            child.color = newColor;
        }
    }

    private void UpdateLifeBar()
    {
        health = Mathf.Clamp(health, 0, maxhealth);
        lifeBarImage.fillAmount = health / maxhealth;
    }

    private void CheckDeath()
    {
        if (health <= 0 && !isDead)
        {
            health = 0;
            isDead = true;
            Die();
        }
    }

    private void Die()
    {
        myAnimator.SetTrigger(AnimParameterDead);
        InputManager.Instance.ToggleInputActionsState(false);
        AudioSource.PlayClipAtPoint(dyingSound, transform.position);
    }
}