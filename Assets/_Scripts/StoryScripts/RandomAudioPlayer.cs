using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomAudioPlayer : MonoBehaviour
{
    [SerializeField] 
    private List<AudioClip> audioClips = new List<AudioClip>();
    [SerializeField]
    private float delayBetweenClips = 8f;
    
    private AudioSource audioSource;
    private bool isPlaying = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Start()
    {
        StartContinuousPlay();
    }

    public void StartContinuousPlay()
    {
        if (!isPlaying)
        {
            isPlaying = true;
            StartCoroutine(PlayClipsContinuously());
        }
    }

    public void StopPlaying()
    {
        isPlaying = false;
        audioSource.Stop();
    }

    private IEnumerator PlayClipsContinuously()
    {
        while (isPlaying && audioClips.Count > 0)
        {
            PlayRandomClip();
            // Wait for current clip to finish
            while (audioSource.isPlaying)
            {
                yield return null;
            }
            // Add delay after clip finishes
            yield return new WaitForSeconds(delayBetweenClips);
        }
    }

    private void PlayRandomClip()
    {
        if (audioClips.Count > 0)
        {
            int index = Random.Range(0, audioClips.Count);
            audioSource.clip = audioClips[index];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No audio clips assigned.");
        }
    }
}