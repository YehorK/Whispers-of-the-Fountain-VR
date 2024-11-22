using UnityEngine;

public class SplashWater : MonoBehaviour
{
    [Header("Splash Sound Settings")]
    public AudioClip splashSound; // Assign the sound clip in the Inspector
    private AudioSource audioSource; // The audio source for playing the sound

    private void Start()
    {
        // Get the AudioSource component (if not already attached)
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is a crystal
        if (other.gameObject.CompareTag("snake")) // Tag your crystals as "Crystal"
        {
            // Play the splash sound (only if the sound is assigned)
            if (audioSource != null && splashSound != null)
            {
                audioSource.PlayOneShot(splashSound); // Play the sound once
            }

        }
    }
}