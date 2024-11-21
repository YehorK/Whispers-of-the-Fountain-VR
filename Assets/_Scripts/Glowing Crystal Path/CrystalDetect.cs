using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalDetect : MonoBehaviour
{
    private CrystalCollector collector;  // Reference to the CrystalCollector script

    void Start()
    {
        // Find the CrystalCollector in the scene (it should be attached to a manager GameObject)
        collector = GameObject.FindObjectOfType<CrystalCollector>();

        if (collector == null)
        {
            Debug.LogError("CrystalCollector not found in the scene!");
        }
    }

    // This method will be called when the player triggers the crystal collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided with the crystal is the player
        if (other.CompareTag("Player"))
        {
            // Log which crystal was collected (for debugging purposes)
            Debug.Log("Crystal Collected: " + gameObject.name);

            // Call the CollectCrystal method in CrystalCollector to handle the collection
            collector?.CollectCrystal(this.gameObject); // Pass this crystal to the manager for handling collection
        }
    }
}
