using UnityEngine;

public class EndScene : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource
    
    public OgopogoAppearance ogopogoScript; // Reference to OgopogoAppearance script
    public GameObject snake; // Reference to the snake object
    
    private bool hasInvoked = false;

    void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned.");
        }

        if (ogopogoScript == null || snake == null)
        {
            Debug.LogError("Target script is not assigned.");
        }
    }

    void Update()
    {
        if (audioSource != null && !audioSource.isPlaying && !hasInvoked)
        {
            Debug.Log("Sound has finished playing. Invoking the target method.");
            InvokeTargetMethod();
        }
    }

    private void InvokeTargetMethod()
    {
        hasInvoked = true;

        if (ogopogoScript != null)
        {
            ogopogoScript.SetSnake(snake);

            // Enable the OgopogoAppearance script
            ogopogoScript.enabled = true;

            // Trigger the rising logic in OgopogoAppearance
            ogopogoScript.Start();
        }
    }
}