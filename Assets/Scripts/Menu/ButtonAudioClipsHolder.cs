using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudioClipsHolder : MonoBehaviour
{
    [SerializeField] private AudioClip hoverClip;
    [SerializeField] private AudioClip clickClip;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        if(audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public void PlayHover()
    {
        audioSource.PlayOneShot(hoverClip);
    }

    public void PlayClick()
    {
        audioSource.PlayOneShot(clickClip);
    }
}
