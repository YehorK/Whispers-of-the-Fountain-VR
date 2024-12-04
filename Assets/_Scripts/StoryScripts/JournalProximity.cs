using UnityEngine;
using System.Collections;

public class JournalProximity : MonoBehaviour
{
    public AudioClip journalVoiceClip; // Assign the voice clip in the inspector
    private AudioSource audioSource;
    private bool hasTriggered = false;

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
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            PlayJournalVoice();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasTriggered = true;
        }
    }

    private void PlayJournalVoice()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            StartCoroutine(WaitForVoiceToEnd());
        }
    }

    private IEnumerator WaitForVoiceToEnd()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        yield return new WaitForSeconds(3f); // Wait for an additional 3 seconds
        gameObject.SetActive(false); // Make the journal disappear
    }
}