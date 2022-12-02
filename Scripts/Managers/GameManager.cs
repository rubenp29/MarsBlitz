using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } = null;

    private int level = 0;

    public bool IsPaused { get; private set; } = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private IEnumerator LoadNextLevelAsync(int level)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(level);
        while (!asyncLoad.isDone)
        {
            print(asyncLoad.progress);
            yield return null;
        }

        print(asyncLoad.progress);
        yield return null;
    }

    public void LoadNextLevel()
    {
        if (level + 1 < SceneManager.sceneCountInBuildSettings)
        {
            level++;
            //SceneManager.LoadScene(level);
            StartCoroutine(LoadNextLevelAsync(level));
            //UIManager.Instance.ShowHUD(true);
        }
        else
        {
            print("End Game!!!");
        }

        if (level == SceneManager.sceneCountInBuildSettings - 1)
        {
            //UIManager.Instance.ShowHUD(false);
        }
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadNextLevelAsync(0));
        level = 0;
    }

    public void LoadGame()
    {
        StartCoroutine(LoadNextLevelAsync(3));
        //SceneManager.LoadScene("Game");
        UIManager.Instance.ShowGame();
    }


    public void LoadCredits()
    {
        StartCoroutine(LoadNextLevelAsync(1));
        //SceneManager.LoadScene("Credits");
    }

    public void LoadSettings()
    {
        StartCoroutine(LoadNextLevelAsync(2));
        //SceneManager.LoadScene("Settings");
    }

    public void ShowDeathPanel()
    {
        UIManager.Instance.HideHud();
        UIManager.Instance.CanPause(false);
    }

    public void PlayCutScene()
    {
        StartCoroutine(LoadNextLevelAsync(4));
        //SceneManager.LoadScene("CutScene");
    }

    public void ShowSecretRoom()
    {
        StartCoroutine(LoadNextLevelAsync(5));
    }
    
    public void SkipIntro()
    {
        StartCoroutine(LoadNextLevelAsync(3));
    }
}