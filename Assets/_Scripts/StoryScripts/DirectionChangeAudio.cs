using UnityEngine;

public class DirectionChangeAudio : MonoBehaviour
{
    private AudioSource audioSource;
    private float previousY;
    private bool wasMovingUp;
    private bool hasPlayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        previousY = transform.position.y;
        wasMovingUp = false;
    }

    void Update()
    {
        float currentY = transform.position.y;
        bool isMovingUp = currentY > previousY;

        // Detect direction change
        if (!hasPlayed && wasMovingUp != isMovingUp)
        {
            audioSource.Play();
            hasPlayed = true;
        }

        wasMovingUp = isMovingUp;
        previousY = currentY;
    }
}