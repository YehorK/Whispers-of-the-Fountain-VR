using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalMechanics : MonoBehaviour
{
    [SerializeField] private GameObject journalClosed;  // Reference to the closed journal
    [SerializeField] private GameObject journalOpen;    // Reference to the open journal

    private Renderer journalOpenRenderer;
    private Renderer journalClosedRenderer;

    void Start()
    {
        // Get the Renderer components for both the open and closed journals
        if (journalOpen != null)
        {
            journalOpenRenderer = journalOpen.GetComponent<Renderer>();
            journalOpenRenderer.enabled = false;  // Initially make the open journal invisible
        }

        if (journalClosed != null)
        {
            journalClosedRenderer = journalClosed.GetComponent<Renderer>();
            journalClosedRenderer.enabled = true;  // Initially keep the closed journal visible
        }
    }

    // This function is called when another collider enters the trigger collider of the empty GameObject
    void OnTriggerEnter(Collider other)
    {
        // Check if the player is the one interacting with the trigger
        if (other.CompareTag("Player"))
        {
            // Make the closed journal invisible and the open journal visible
            if (journalClosedRenderer != null)
            {
                journalClosedRenderer.enabled = false;  // Hide the closed journal
            }

            if (journalOpenRenderer != null)
            {
                journalOpenRenderer.enabled = true;    // Show the open journal
            }
        }
    }

}
