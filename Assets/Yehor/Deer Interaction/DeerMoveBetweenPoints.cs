using UnityEngine;

public class DeerMoveBetweenPoints : MonoBehaviour
{
    public GameObject objectToMove; // Reference to the Deer
    public Transform pointA;        // Reference to Start point
    public Transform pointB;        // Reference to End point
    public float speed = 2.0f;      // Speed of movement

    private bool movingToB = true;
    private bool isFollowingCarrot = false;

    void Start()
    {
        // Place the deer at pointA when the game starts
        if (objectToMove != null && pointA != null)
        {
            float startYPositionOffset = 0.06f;
            Vector3 startPosition = pointA.position;
            startPosition.y -= startYPositionOffset; // Apply the y-axis offset
            objectToMove.transform.position = startPosition;
        }
    }

    void Update()
    {
        if (objectToMove == null || pointA == null || pointB == null)
        {
            Debug.LogWarning("Please assign the objectToMove, pointA, and pointB in the Inspector.");
            return;
        }

        if (isFollowingCarrot) return; // Pause movement if following the player

        // Determine target based on the current direction
        Transform target = movingToB ? pointB : pointA;

        // Calculate the direction to the target
        Vector3 direction = (target.position - objectToMove.transform.position).normalized;

        // Move the object towards the target
        objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, target.position, speed * Time.deltaTime);

        // Rotate the object to face the movement direction
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            objectToMove.transform.rotation = Quaternion.Slerp(objectToMove.transform.rotation, targetRotation, speed * Time.deltaTime);
        }

        // Switch direction if close enough to the target
        if (Vector3.Distance(objectToMove.transform.position, target.position) < 0.1f)
        {
            movingToB = !movingToB;
        }
    }

    // Method to start and stop following the player, called from another script
    public void SetFollowingCarrot(bool follow)
    {
        isFollowingCarrot = follow;
    }

}
