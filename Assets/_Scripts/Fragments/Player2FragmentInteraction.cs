using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Player2FragmentInteraction : MonoBehaviour
{
    public FragmentCollectionSceneActivation fragmentCollectionSceneActivation;
    private AudioSource audioSource;
    public AudioClip collectionSound;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        // Get or add AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Setup VR grab interaction
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable == null)
        {
            grabInteractable = gameObject.AddComponent<XRGrabInteractable>();
        }

        // Configure grab interactable
        grabInteractable.selectEntered.AddListener(OnGrabbed);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        CollectFragment();
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

        // Trigger the collection in the InteractionManager
        if (fragmentCollectionSceneActivation != null)
        {
            fragmentCollectionSceneActivation.FragmentCollected(gameObject);
        }
        else
        {
            Debug.LogWarning("InteractionManager is not assigned to this collectible object.");
        }

        // Deactivate or destroy the object after collection
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        }
    }
}