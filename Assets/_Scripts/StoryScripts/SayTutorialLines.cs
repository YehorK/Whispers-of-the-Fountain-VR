using UnityEngine;
using System.Collections;

public class SayTutorialLines : MonoBehaviour
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
        audioSource.playOnAwake = false; // Disable play on awake
        StartCoroutine(PlayVoiceAfterDelay(3f)); // Start coroutine to play after delay
    }

    private IEnumerator PlayVoiceAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayJournalVoice();
    }

    public void PlayJournalVoice()
    {
        audioSource.Play();
        StartCoroutine(WaitForVoiceToEnd());
    }

    private IEnumerator WaitForVoiceToEnd()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        gameObject.SetActive(false); // Make the journal disappear
    }
}