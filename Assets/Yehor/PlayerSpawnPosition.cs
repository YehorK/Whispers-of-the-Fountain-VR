using UnityEngine;
using UnityEngine.XR;

public class PlayerSpawnPosition : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;  // The target position to spawn the player
    [SerializeField] private GameObject xrRigCameraOffset;         // Reference to your XR Rig GameObject

    private void Start()
    {
        // Ensure the XR Rig and spawn position are set
        if (xrRigCameraOffset != null && spawnPosition != null)
        {
            // Move the XR Rig to the spawn position
            MovePlayerToSpawnPosition();
        }
        else
        {
            Debug.LogError("XR Rig or Spawn Position not assigned!");
        }
    }

    // This method moves the XR Rig to the spawn position
    private void MovePlayerToSpawnPosition()
    {
        Transform offset = xrRigCameraOffset.transform;  // Get the transform of the XR Rig

        // Move the XR Rig to the spawn position (and also take rotations into account)
        offset.position = spawnPosition.position;
        offset.rotation = spawnPosition.rotation; 
    }
}
