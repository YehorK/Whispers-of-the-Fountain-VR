using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class JournalInteraction : MonoBehaviour
{
    public AudioClip voiceClip1;
    public AudioClip voiceClip2;
    public TextMeshProUGUI floatingText;
    private AudioSource audioSource;
    private XRGrabInteractable grabInteractable;
    private bool isInteracted = false;
    private bool hasPlayedAudio = false;
    private readonly object lockObject = new object();

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        floatingText.enabled = false;
        Debug.Log("JournalInteraction started.");

        // Disable the audio source at the start
        audioSource.enabled = false;

        // Use the newer selectEntered event instead of deprecated onSelectEntered
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        lock (lockObject)
        {
            if (!hasPlayedAudio)
            {
                // Enable and play the audio source when the journal is grabbed
                audioSource.enabled = true;
                audioSource.Play();
                hasPlayedAudio = true;

                if (!isInteracted)
                {
                    isInteracted = true;
                    PlayVoiceClip();
                    ShowFloatingText();
                }
            }
        }
    }

    void PlayVoiceClip()
    {
        audioSource.clip = voiceClip1;
        audioSource.Play();
        audioSource.PlayOneShot(voiceClip1);
        Invoke("PlaySecondVoiceClip", voiceClip1.length);
    }

    void PlaySecondVoiceClip()
    {
        audioSource.clip = voiceClip2;
        audioSource.Play();
    }

    void ShowFloatingText()
    {
        floatingText.text = "Touch the doorknob to head to the UBC Courtyard.";
        floatingText.enabled = true;
    }
}