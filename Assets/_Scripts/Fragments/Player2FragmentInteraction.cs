using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Player2FragmentInteraction : MonoBehaviour
{
    public FragmentCollectionSceneActivation fragmentCollectionSceneActivation;
    private AudioSource audioSource;
    public AudioClip collectionSound;

    void Start()
    {
        // Get or add AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectFragment();
        }
    }

    private void CollectFragment()
    {
        // Play collection sound if assigned
        if (collectionSound != null)
        {
            Debug.Log("Attempting to play sound: " + collectionSound.name);
            audioSource.PlayOneShot(collectionSound);
        }
        else 
        {
            Debug.Log("collectionSound is null");
        }

        // Wait for the audio to finish before deactivating the object
        StartCoroutine(DeactivateAfterSound());


        // Deactivate or destroy the object after collection
        // DONT NEED IT, SINCE EVERYTHING IS HANDLED BY THE GAME PROGRESS MANAGER
        //gameObject.SetActive(false);
    }

    private IEnumerator DeactivateAfterSound()
    {
        // Wait for the sound to finish
        yield return new WaitForSeconds(collectionSound.length);

        // Trigger the collection in the InteractionManager
        if (fragmentCollectionSceneActivation != null)
        {
            fragmentCollectionSceneActivation.FragmentCollected(gameObject);
        }
        else
        {
            Debug.LogWarning("InteractionManager is not assigned to this collectible object.");
        }
    }

}