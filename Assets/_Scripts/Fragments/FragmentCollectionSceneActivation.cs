using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentCollectionSceneActivation : MonoBehaviour
{
    public GameObject[] fragmentsToCollect; // fragments to collect
    public GameObject[] interactionParts; // Parts to activate/deactivate

    private int currentIndex = 0; // Tracks which object is being handled

    void Start()
    {
        // Ensure only the first interaction part is active at the start
        for (int i = 0; i < interactionParts.Length; i++)
        {
            interactionParts[i].SetActive(i == 0);
        }
    }

    public void FragmentCollected(GameObject collectedObject)
    {
        // Ensure the object matches the current target and is not already handled
        if (currentIndex < fragmentsToCollect.Length && collectedObject == fragmentsToCollect[currentIndex])
        {
            // Deactivate current interaction part
            if (currentIndex < interactionParts.Length)
            {
                interactionParts[currentIndex].SetActive(false);
            }

            // Activate next interaction part
            if (currentIndex + 1 < interactionParts.Length)
            {
                interactionParts[currentIndex + 1].SetActive(true);
            }

            // Move to the next object
            currentIndex++;
        }
    }
}
