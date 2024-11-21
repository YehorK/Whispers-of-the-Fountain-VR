using UnityEngine;

public class CarrotPositionReset : MonoBehaviour
{
    // Reference to an empty GameObject for the reset position
    [SerializeField] Transform resetTransform;

    private Vector3 lastPosition; // To track the object's last position
    private float stationaryTime = 0f; // To track how long the object hasn't moved
    [SerializeField] float resetTime = 10f; // Time in seconds to trigger the reset

    void Start()
    {
        // Initialize last position to the current position of the object
        lastPosition = transform.position;
    }

    void Update()
    {
        // Check if the object has moved
        if (transform.position == lastPosition)
        {
            stationaryTime += Time.deltaTime;

            // Reset position if stationary time exceeds the threshold
            if (stationaryTime >= resetTime)
            {
                ResetObjectPosition();
            }
        }
        else
        {
            // If the object has moved, reset the stationary timer
            stationaryTime = 0f;
            lastPosition = transform.position;
        }
    }

    // Reset the object's position to the empty GameObject's position
    private void ResetObjectPosition()
    {
        if (resetTransform != null)
        {
            transform.position = resetTransform.position;
        }
        else
        {
            Debug.LogWarning("Reset Transform is not assigned!");
        }
        stationaryTime = 0f; // Reset the stationary time
    }
}
