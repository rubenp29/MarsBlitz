using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField] private VideoPlayer myVideo = null;

    void Start()
    {
        myVideo.loopPointReached += EndReached;
    }

    // Video componets
    private void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        GameManager.Instance.LoadGame();
    }
}