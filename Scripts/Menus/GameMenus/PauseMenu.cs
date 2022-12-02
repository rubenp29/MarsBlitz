using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance { get; private set; } = null;
    public static bool GameIsPaused = false;

    [SerializeField] private GameObject pauseMenuUI;
    private PlayerInput playerInput;
    private bool pause;
    private bool canPause = false;
   
    private void Update()
    {
        pause = playerInput.player.pause.triggered;

        if (pause && canPause)
        {
            if (GameIsPaused)
            {
                
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void CanPause(bool value)
    {
        canPause = true;
    }
}