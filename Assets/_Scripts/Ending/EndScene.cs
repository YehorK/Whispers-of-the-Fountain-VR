using UnityEngine;

public class EndScene : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource
    
    public OgopogoAppearance ogopogoScript; // Reference to OgopogoAppearance script
    public GameObject snake; // Reference to the snake object
    
    private bool audioStarted = false; // Tracks if the audio has started playing
    private bool hasInvoked = false; // Ensures the target method is only invoked once
    
    void Update()
    {
        if (audioSource == null)
            return; // Ensure audioSource is valid

        // Check if the audio has started playing
        if (audioSource.isPlaying && !audioStarted)
        {
            audioStarted = true;
            Debug.Log("Audio has started playing.");
        }

        // After the audio has started, check if it has stopped
        if (audioStarted && !audioSource.isPlaying && !hasInvoked)
        {
            Debug.Log("Audio has finished playing. Invoking the target method.");
            InvokeTargetMethod();
        }
    }

    private void InvokeTargetMethod()
    {
        hasInvoked = true;

        if (ogopogoScript != null && snake != null)
        {
            ogopogoScript.SetSnake(snake);

            // Enable the OgopogoAppearance script
            ogopogoScript.enabled = true;
            ogopogoScript.riseHeight = 20f;
            ogopogoScript.delayBeforeRising = 0f;
            ogopogoScript.destroyAfter = true;
            
            // Trigger initialization logic in OgopogoAppearance
            ogopogoScript.Start(); // Replace Start() with a custom method
        }
    }
}