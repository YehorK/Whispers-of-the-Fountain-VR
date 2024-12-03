using UnityEngine;

public class JournalProximity : MonoBehaviour
{
    public AudioClip journalVoiceClip; // Assign the voice clip in the inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = journalVoiceClip;
        audioSource.playOnAwake = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayJournalVoice();
        }
    }

    private void PlayJournalVoice()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}