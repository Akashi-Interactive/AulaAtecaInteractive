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
        }
        else
        {
            Destroy(gameObject);
        }
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
}
