using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoService : MonoBehaviour
{
    public static VideoService Instance;

    [SerializeField] private VideoPlayer VideoPlayer;
    [SerializeField] private RawImage RawImage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            VideoPlayer.loopPointReached += StopVideo;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void StopVideo(VideoPlayer source)
    {
        RawImage.gameObject.SetActive(false);
        AudioManager.Instance.UnPauseAudio();
    }

    public void PlayVideo(VideoClip videoClip)
    {
        VideoPlayer.Stop();
        RawImage.gameObject.SetActive(true);
        VideoPlayer.clip = videoClip;
        VideoPlayer.Play();
    }

    public void StopVideo()
    {
        VideoPlayer.Stop();
        RawImage.gameObject.SetActive(false);
    }

    public void PauseVideo()
    {
        VideoPlayer.Pause();
    }

    public void UnPauseVideo()
    {
        VideoPlayer.Play();
    }
}
