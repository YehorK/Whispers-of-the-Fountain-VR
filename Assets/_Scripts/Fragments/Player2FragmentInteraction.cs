using UnityEngine;

public class Player2FragmentInteraction : MonoBehaviour
{
    public FragmentCollectionSceneActivation fragmentCollectionSceneActivation;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Trigger the collection in the InteractionManager
            if (fragmentCollectionSceneActivation != null)
            {
                fragmentCollectionSceneActivation.FragmentCollected(gameObject);
            }
            else
            {
                Debug.LogWarning("InteractionManager is not assigned to this collectible object.");
            }

            // Deactivate or destroy the object after collection
            gameObject.SetActive(false);
        }
    }
}

