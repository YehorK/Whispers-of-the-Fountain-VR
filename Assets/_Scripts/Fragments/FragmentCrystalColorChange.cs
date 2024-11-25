using UnityEngine;

public class FragmentCrystalColorChange : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;   // Speed of the vertical movement (up and down)
    [SerializeField] private float moveDistance = 0.1f;  // How much the object moves on the Y-axis
    [SerializeField] private float colorSpeed = 0.2f;   // Speed for the color transition

    private Transform objectTransform; // Reference to the child object's Transform
    private Renderer objectRenderer;   // Reference to the child object's Renderer for color changes

    private float initialYPosition;    // Initial Y position for up/down movement

    void Start()
    {
        // Assuming the object of interest is a child of the empty GameObject
        objectTransform = transform.Find("Crystal Fragment"); // Change "ObjectOfInterest" to your actual child object's name
        if (objectTransform != null)
        {
            objectRenderer = objectTransform.GetComponent<Renderer>(); // Get the Renderer for color changes
            initialYPosition = objectTransform.position.y; // Store initial Y position for vertical movement
        }
        else
        {
            Debug.LogError("Object of interest not found in child objects.");
        }
    }

    void Update()
    {
        // Ensure we have a valid object to manipulate
        if (objectTransform == null || objectRenderer == null) return;

        // Handle the up and down movement (Y-axis oscillation)
        float newYPosition = initialYPosition + Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        objectTransform.position = new Vector3(objectTransform.position.x, newYPosition, objectTransform.position.z);

        // Handle smooth rainbow color cycling
        float hue = Mathf.PingPong(Time.time * colorSpeed, 1);  // Oscillating between 0 and 1 to cycle through the color spectrum
        objectRenderer.material.color = Color.HSVToRGB(hue, 1f, 1f);  // Convert HSV to RGB, keeping full saturation and brightness
    }
}
