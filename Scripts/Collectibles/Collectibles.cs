using System;
using TMPro;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public static Collectibles Instance { get; private set; }
    [SerializeField] private GameObject menuPanel = null;
    [SerializeField] private GameObject glow;
    [SerializeField] private Sprite normal;
    [SerializeField] private Animator myAnim;
    [SerializeField] private TextMeshProUGUI pickupText;
    private SpriteRenderer mySpriteRenderer;
    private bool canEnter = false;
    private bool canShow = false;
    private float canPlay = 0f;
    private bool show = false;
 

    private void Awake()
    {
        Instance = this;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnim = GetComponent<Animator>();
    }

    public void ShowPanel()
    {
        menuPanel.SetActive(true);
        myAnim.Play("collectible_found");
        Invoke(nameof(HideStuff), 3f);
    }
    private void Start()
    {
        pickupText.gameObject.SetActive(false);
    }

    private void Update()
    {
        Pick();
    }

    private void Pick()
    {
        if (canPlay == 0 && Input.GetKeyDown(KeyCode.E) && canEnter == true)
        {
            canPlay++;
            canShow = true;
            show = true;
            pickupText.gameObject.SetActive(false);
    
            myAnim.SetTrigger("apresentar");
        }
        else if (canPlay >= 1)
        {
            glow.SetActive(false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Artur"))
        {
            pickupText.gameObject.SetActive(true);
            canEnter = true;
            glow.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Artur"))
        {
            pickupText.gameObject.SetActive(false);
            canEnter = false;
            glow.SetActive(false);
        }
    }
    
    private void HideStuff()
    {
        canEnter = false;
        menuPanel.SetActive(false);
        glow.SetActive(false);
        mySpriteRenderer.sprite = normal;
    }

  
}