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
        // Check if the trigger has already been activated
        if (hasTriggered)
            return;

        // Check if any objects with the specified tags exist
        if (AreAnyObjectsWithTagsPresent())
            return;

        // Trigger the appearance of Ogopogo
        TriggerOgopogoAppearance();
    }

    private bool AreAnyObjectsWithTagsPresent()
    {
        // Get all objects in the scene
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        // Check for objects with the specified tags
        foreach (GameObject obj in allObjects)
        {
            if ((obj.CompareTag("crystal") || obj.CompareTag("finalJournal")) && obj.scene.IsValid())
            {
                return true; // Return true if an object with the specified tags exists
            }
        }

        return false; // Return false if no objects with the specified tags are found
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
        
        hasTriggered = true;
        // Trigger the rising logic in OgopogoAppearance
        ogopogoScript.Start();
    }
}