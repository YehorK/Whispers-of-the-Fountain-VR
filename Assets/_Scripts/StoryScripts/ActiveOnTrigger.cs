using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnTrigger : MonoBehaviour
{
    public BoundingBoxTrigger boundingBoxTrigger;

    void Start()
    {
        if (boundingBoxTrigger != null)
        {
            boundingBoxTrigger.onPlayerEnter.AddListener(ShowJournal);
        }
        else
        {
            Debug.LogError("BoundingBoxTrigger not assigned in the Inspector.");
        }

        // Ensure the journal is initially inactive
        gameObject.SetActive(false);
    }

    private void ShowJournal()
    {
        gameObject.SetActive(true);

    }
}