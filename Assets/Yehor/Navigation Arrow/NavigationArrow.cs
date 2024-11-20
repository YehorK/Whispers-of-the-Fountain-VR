using UnityEngine;

public class NavigationArrow : MonoBehaviour
{
    public Transform target;        // The target to point toward
    public Transform player;        // The player's position or VR rig
    public float distanceInFront = 2f;  // Distance to keep the arrow in front of the player
    public float groundOffset = 0.1f;   // Offset from the ground to keep the arrow at ground level

    void Update()
    {
        if (target != null && player != null)
        {
            // Set the arrow’s position at ground level in front of the player
            Vector3 newPosition = player.position + player.forward * distanceInFront;
            newPosition.y = groundOffset;  // Set y-position to ground level with specified offset
            transform.position = newPosition;

            // Calculate the direction to the target
            Vector3 targetDirection = target.position - transform.position;
            targetDirection.y = 0; // Keep it in the horizontal plane

            // Apply the rotation to point toward the target
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            // Create an offset rotation to blend between the Z and X axes
            Quaternion offsetRotation = Quaternion.Euler(0, -45, 0); // 45 degrees between Z and X
            transform.rotation = targetRotation * offsetRotation;
        }
    }


}
