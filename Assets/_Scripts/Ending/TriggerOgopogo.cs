using Unity.XR.CoreUtils;
using UnityEngine;

/*
 * This Script handles the triggering of Ogopogo Appearance script! -> Invoking script happens here
 * The script checks if whether the parent "--fragments" still has any children left
 * If no children left (everything thrown into the fountain), Ogopogo appears and rises from the fountain!
 */

public class TriggerOgopogo : MonoBehaviour
{
    public OgopogoAppearance ogopogoScript; // Reference to OgopogoAppearance script
    public GameObject snake; // Reference to the snake object
    private bool hasTriggered = false; // To ensure the trigger logic runs only once

    private void Update()
    {
        if (!hasTriggered && AreAllChildrenDestroyed())
        {
            Debug.Log("All child objects are inactive.");
            hasTriggered = true;
            TriggerOgopogoAppearance();
        }
    }

    // Check if all child objects are inactive
    private bool AreAllChildrenDestroyed()
    {
        foreach (Transform child in transform)
        {
            // Check if the child is still in the scene (not destroyed) and either active or inactive
            if (child.gameObject != null)
            {
                return false; // If the child is not destroyed or is active/inactive, return false
            }
        }

        return true; // All children are destroyed (or inactive) at this point
    }

    private void TriggerOgopogoAppearance()
    {
        Debug.Log("Triggering Ogopogo appearance logic.");

        // Dynamically assign references
        if (ogopogoScript == null || snake == null)
        {
            Debug.LogError("Ogopogo script or snake is not assigned in the Inspector!");
            return;
        }

        ogopogoScript.SetSnake(snake);

        // Enable the OgopogoAppearance script
        ogopogoScript.enabled = true;

        // Trigger the rising logic in OgopogoAppearance
        ogopogoScript.Start();
    }
}