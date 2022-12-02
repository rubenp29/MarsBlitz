using System;
using UnityEngine;
using UnityEngine.Video;


public class StartButton : MonoBehaviour
{
    public void StartPlaying()
    {
        GameManager.Instance.PlayCutScene();
    }
}