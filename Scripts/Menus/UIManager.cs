using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; } = null;

    //UI Components
    [SerializeField] private GameObject hudPanel;
    private Chest currentChest;

    // Dialogs Components
    [SerializeField] private GameObject dialogPanel;

    //MenuComponents
    [SerializeField] private GameObject menuPanel;

    [SerializeField] private GameObject ArturTalk;
    [SerializeField] private GameObject ManobroTalk;
    [SerializeField] private GameObject DeathPanel;
    [SerializeField] private GameObject showWinPanel;
    [SerializeField] private GameObject gun;
    private Animator myAnimator;

    //Audiocomponents
    private AudioSource myAudioSource;
    [SerializeField] private AudioClip open;
    [SerializeField] private AudioClip close;
    [SerializeField] private GameObject audioSource;

    //bools
    private bool GameIsPaused = false;
    private bool canPause = false;
    private bool collectiblePopUp = false;

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
    }

    public void CanPause(bool value)
    {
        canPause = value;
    }


    public void ShowWinPanel()
    {
        CanPause(false);
        InputManager.Instance.ToggleInputActionsState(false);
        showWinPanel.SetActive(true);
    }

    public void HideHud()
    {
        InputManager.Instance.ToggleInputActionsState(false);
        DeathPanel.SetActive(true);
        hudPanel.SetActive(false);
    }

    public void ShowGame()
    {
        DeathPanel.SetActive(false);
        hudPanel.SetActive(true);
    }

    public void ShowArturPanel()
    {
        ArturTalk.SetActive(true);
        CanPause(false);
    }

    public void ShowManobroPanel()
    {
        ManobroTalk.SetActive(true);
       Destroy(gun);
    }

    private void Start()
    {
        myAnimator = menuPanel.GetComponentInChildren<Animator>();
        myAudioSource = menuPanel.GetComponentInChildren<AudioSource>();
        audioSource.SetActive(true);
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab)) && canPause &&
            collectiblePopUp == false)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && collectiblePopUp == true)
        {
            CollectibleResume(currentChest);
        }
    }

    private void Pause()
    {
        PlayerMovement.Instance.CanMove(false);
        menuPanel.SetActive(true);
        myAnimator.SetTrigger("show");
        myAudioSource.PlayOneShot(open);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void CollectiblePause(Chest chest)
    {
        currentChest = chest;
        canPause = false;
        collectiblePopUp = true;

        PlayerMovement.Instance.CanMove(false);
        //Time.timeScale = 0;
    }

    private void CollectibleResume(Chest chest)
    {
        chest.HideStuff();
        PlayerMovement.Instance.CanMove(true);
        Time.timeScale = 1;
        collectiblePopUp = false;
        canPause = true;
    }

    // Called by the btn on the GameMenu
    public void Resume()
    {
        PlayerMovement.Instance.CanMove(true);
        myAudioSource.PlayOneShot(close);
        myAnimator.SetTrigger("hid");
        Time.timeScale = 1;
        GameIsPaused = false;
        StartCoroutine(ShowGames());
    }

    private IEnumerator ShowGames()
    {
        yield return new WaitForSeconds(1f);
        menuPanel.SetActive(false);
    }
}