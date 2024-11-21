using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class JournalInteraction : MonoBehaviour
{
    public AudioClip voiceClip1;
    public AudioClip voiceClip2;
    public TextMeshProUGUI floatingText;
    public AudioSource audioSource; // Add this field
    private XRGrabInteractable grabInteractable;
    private bool isInteracted = false;
    private bool hasPlayedAudio = false;
    private readonly object lockObject = new object();
    private bool hasPlayed = false; // Add this flag

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        floatingText.enabled = false;
        Debug.Log("JournalInteraction started.");

        // Subscribe to grab events
        grabInteractable.selectEntered.AddListener(OnGrab);
        
        // Disable the audio source at the start
        audioSource.enabled = false;
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        if (!hasPlayedAudio)
        {
            audioSource.enabled = true;
            if (voiceClip1 != null)
            {
                audioSource.clip = voiceClip1;
                audioSource.Play();
            }
            hasPlayedAudio = true; // Set flag to prevent future plays
            isInteracted = true;
            StartCoroutine(ShowTextAfterDelay(6f)); // Start coroutine to show text after 6 seconds
        }
    }

    private IEnumerator ShowTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        floatingText.enabled = true; // Enable the text after the delay
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed)
        {
            audioSource.Play(); // Play the audio clip
            hasPlayed = true; // Set the flag to true to prevent replay
        }
    }

    private void OnDestroy()
    {
        // Clean up event subscription
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
        }
    }
}