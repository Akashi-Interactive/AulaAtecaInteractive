using UnityEngine;
using UnityEngine.Video;

public class VideoButton : MonoBehaviour
{
    [SerializeField] private VideoClip videoClip;

    public void PlayVideo()
    {
        VideoService.Instance.PlayVideo(videoClip);
        AudioManager.Instance.PauseAudio();
    }
}
