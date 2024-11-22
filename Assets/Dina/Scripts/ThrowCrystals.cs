using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowableObjectParent : MonoBehaviour
{
    [Header("Throw Settings")]
    [Range(100, 1000)] public float throwForce = 500f; // Adjustable throw force
    private Rigidbody rb;
    private XRGrabInteractable grabInteractable;
    private Transform crystal; // Reference to the crystal (child object)
    private Vector3 lastPosition; // Tracks position for velocity calculation
    private bool isGrabbed = false;

    private void Start()
    {
        // Find the crystal (child object with Rigidbody)
        crystal = transform.Find("crystal"); // Assumes the crystal is the first child
        rb = crystal.GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Add event listeners for grab and release
        grabInteractable.onSelectEntered.AddListener(GrabObject);
        grabInteractable.onSelectExited.AddListener(ThrowObject);
    }

    private void Update()
    {
        // Track the position of the grabbing controller while the object is grabbed
        if (isGrabbed)
        {
            lastPosition = grabInteractable.selectingInteractor.transform.position;
        }
    }

    private void GrabObject(XRBaseInteractor interactor)
    {
        // Disable physics while the crystal is grabbed
        rb.isKinematic = true;
        isGrabbed = true;

        // Store the initial position for velocity calculations
        lastPosition = interactor.transform.position;
    }

    private void ThrowObject(XRBaseInteractor interactor)
    {
        // Re-enable physics when the crystal is released
        rb.isKinematic = false;
        isGrabbed = false;

        // Calculate the throw velocity based on interactor motion
        Vector3 throwVelocity = (interactor.transform.position - lastPosition) / Time.deltaTime;
        rb.velocity = throwVelocity * throwForce;
    }
}
