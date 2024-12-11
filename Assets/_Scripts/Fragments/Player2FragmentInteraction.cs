using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Player2FragmentInteraction : MonoBehaviour
{
    public FragmentCollectionSceneActivation fragmentCollectionSceneActivation;
    private AudioSource audioSource;
    public AudioClip collectionSound;
    private new Renderer renderer;

    void Start()
    {
        // Get or add AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        renderer = GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogWarning("Renderer not found on this GameObject.");
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

        // setting the renderer to false to, but the object stays active to play the audio
        renderer.enabled = false;

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