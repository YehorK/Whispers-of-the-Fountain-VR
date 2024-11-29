using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/*
    This script mimics the grab & throw action. 
    It has Rigidbody & XRGrabInteractable components.
    - Grab behavior: Stops physics (kinematic mode).
    - Throw behavior: Applies a force when the object is released.

    Additionally, it detects collisions with a water plane to sink and applies bouncing behavior for other surfaces.
*/

public class Throwable : MonoBehaviour
{
    public float throwForce = 50f; // The force applied when throwing
    public float sinkingForce = 10f;  // Force to simulate sinking
    public float dragMultiplier = 2f; // Multiplier to increase drag for sinking effect

    private Rigidbody rb;
    private bool isGrabbed = false;
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
        isGrabbed = true;
    }

    private void ThrowObject(XRBaseInteractor interactor)
    {
        // Mimic throwing by enabling physics and applying force in the throw direction
        rb.isKinematic = false; 
        isGrabbed = false;

        // Apply a throw force in the direction of the controller
        Vector3 throwDirection = interactor.transform.forward; // Use the interactor's forward direction
        rb.AddForce(throwDirection * throwForce);
    }

    // Called when the crystal collides with another object
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object hit the water plane (assuming the water plane has the "Water" tag)
        if (collision.gameObject.CompareTag("fountain"))
        {
            // Apply a downward force to simulate sinking and increase drag for resistance
            rb.AddForce(Vector3.down * sinkingForce, ForceMode.Force);
            rb.drag *= dragMultiplier; // Increase drag to simulate resistance while sinking
            Debug.Log("Crystal hit the water, sinking...");
        }
    }
}
