using UnityEngine;
using System.Collections;

public class JournalAppearanceTrigger : MonoBehaviour
{
    public BoundingBoxTrigger boundingBoxTrigger;
    public AudioClip journalVoiceClip; // Assign the voice clip in the inspector

    private AudioSource audioSource;

    void Start()
    {
        if (boundingBoxTrigger != null)
        {
            boundingBoxTrigger.onPlayerEnter.AddListener(ShowJournal);
        }
        else
        {
            Debug.LogError("BoundingBoxTrigger not assigned in the Inspector.");
        }

        // Ensure the journal is initially inactive
        gameObject.SetActive(false);

        // Add an AudioSource component to the journal
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = journalVoiceClip;
        audioSource.playOnAwake = false; // Disable play on awake
    }

    private void ShowJournal()
    {
        gameObject.SetActive(true);
        Debug.Log("Journal has appeared.");
        StartCoroutine(PlayAudioAfterDelay(1f));
    }

    private IEnumerator PlayAudioAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.Play();
    }
}