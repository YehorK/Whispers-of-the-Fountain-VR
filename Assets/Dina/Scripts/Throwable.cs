using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/*
 * This Script handles throwing any object!
 * The object can be grabbed and thrown when released
 * If object hits the "fountain" tag, the object is destroyed!
 */

public class Throwable : MonoBehaviour
{
    public float throwForce = 50f; // The force applied when throwing
    private Rigidbody rb;
    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        // Get Rigidbody and XRGrabInteractable components
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Listen to SelectEntered & SelectExited events
        grabInteractable.onSelectEntered.AddListener(GrabObject);
        grabInteractable.onSelectExited.AddListener(ThrowObject);
    }

    private void GrabObject(XRBaseInteractor interactor)
    {
        // Mimic grabbing by disabling physics (kinematic mode)
        rb.isKinematic = true;
    }

    private void ThrowObject(XRBaseInteractor interactor)
    {
        // Mimic throwing by enabling physics and applying force in the throw direction
        rb.isKinematic = false;

        // Apply a throw force in the direction of the controller
        Vector3 throwDirection = interactor.transform.forward; // Use the interactor's forward direction
        rb.AddForce(throwDirection * throwForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entered the fountain trigger area
        if (other.CompareTag("fountain"))
        {
            Debug.Log($"{gameObject.name} entered the fountain and will be destroyed.");
            Destroy(gameObject);
        }
    }
}