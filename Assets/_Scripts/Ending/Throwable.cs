using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Throwable : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private bool isReleased = false;  // To track if the object has been released

    private void Start()
    {
        // Get the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Add listener for the object being released (no longer grabbed)
        grabInteractable.onSelectExited.AddListener(OnReleased);
    }

    private void OnReleased(XRBaseInteractor interactor)
    {
        // The object has been released, set isReleased to true
        isReleased = true;
        Debug.Log($"{gameObject.name} has been released and is ready to be destroyed if it enters the fountain.");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entered the fountain trigger area and if it has been released
        if (isReleased && other.CompareTag("Fragment2Fountain"))
        {
            Debug.Log($"{gameObject.name} entered the fountain after being released and will be destroyed.");
            Destroy(gameObject, 0);  // Destroy immediately on collision with the fountain
        }
    }
}