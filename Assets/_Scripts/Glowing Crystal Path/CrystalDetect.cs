using UnityEngine;

public class CrystalDetect : MonoBehaviour
{
    private CrystalCollector collector;
    private AudioSource audioSource;
    public AudioClip collectionSound; // Drag your sound file in the Unity Inspector

    void Start()
    {
        // Find the CrystalCollector in the scene
        collector = GameObject.FindObjectOfType<CrystalCollector>();
        
        // Get or add AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (collector == null)
        {
            Debug.LogError("CrystalCollector not found in the scene!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Play collection sound if assigned
            if (collectionSound != null)
            {
                audioSource.PlayOneShot(collectionSound);
            }

            Debug.Log("Crystal Collected: " + gameObject.name);
            collector?.CollectCrystal(this.gameObject);
        }
    }
}