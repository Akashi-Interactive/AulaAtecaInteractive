using UnityEngine;

public class AudioInteractable : MonoBehaviour, InteractableObj
{
    [SerializeField] private AudioClip interactClip; 
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
            if(audioSource != null )
                audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void Interact()
    {
        if (interactClip != null)
        {
            audioSource.PlayOneShot(interactClip);
        }
    }
}
