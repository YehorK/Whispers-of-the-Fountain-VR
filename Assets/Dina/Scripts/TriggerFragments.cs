using UnityEngine;

public class TriggerFragments : MonoBehaviour
{
    public GameObject parentObject; // The parent object to activate
    public string crystalTag = "crystal"; // The tag of the child objects to activate first
    public string journalTag = "finalJournal"; // The tag of the child objects to activate after the first ones are destroyed

    private bool isFirstTagDestroyed = false; // Flag to check if the first tag objects are destroyed

    void Start()
    {
        // Ensure the parent object is initially deactivated
        if (parentObject == null)
        {
            Debug.LogError("Parent object not assigned in the Inspector.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the approaching object is the player
        if (other.CompareTag("Player")) // Ensure your player is tagged as "Player"
        {
            Debug.Log("Player has approached the area. Activating specific children.");
            if (parentObject != null)
            {
                // Activate the parent object
                parentObject.SetActive(true);

                // Activate all child objects with the first tag
                ActivateChildrenWithTag(crystalTag);
            }
        }
    }

    // Activate all child objects with the specified tag
    private void ActivateChildrenWithTag(string tag)
    {
        foreach (Transform child in parentObject.transform)
        {
            if (child.CompareTag(tag))
            {
                child.gameObject.SetActive(true); // Activate the child object with the specified tag
                Debug.Log("Activated child: " + child.name);
            }
        }
    }

    // Call this method to check if all objects with the first tag are destroyed
    public void CheckIfFirstTagDestroyed()
    {
        bool allDestroyed = true;
        
        // Loop through all children and check if there are any remaining objects with the first tag
        foreach (Transform child in parentObject.transform)
        {
            // Check if child exists (not destroyed) and is active
            if (child != null && child.CompareTag(crystalTag) == true)
            {
                allDestroyed = false; // If any child with the first tag is still active, set to false
                break;
            }
        }

        // If all first tag objects are destroyed, activate the second tag objects
        if (allDestroyed && !isFirstTagDestroyed)
        {
            isFirstTagDestroyed = true; // Prevent multiple activations
            ActivateChildrenWithTag(journalTag);
            Debug.Log("All crystals destroyed. Activating final journal.");
        }
    }

    // Update method to continuously check if all first tag objects are destroyed
    void Update()
    {
        // Only check if the first set of objects have been destroyed after activation
        if (!isFirstTagDestroyed)
        {
            CheckIfFirstTagDestroyed();
        }
    }
}
