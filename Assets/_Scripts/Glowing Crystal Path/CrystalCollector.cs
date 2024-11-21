using UnityEngine;

public class CrystalCollector : MonoBehaviour
{
    [SerializeField] private GameObject[] crystals;  // Array of all the crystals in the path
    private int currentCrystalIndex = 0;  // Index of the current crystal to collect

    public CrystalShine crystalShine;

    void Start()
    {
        // Initially hide all crystals except the first one
        for (int i = 1; i < crystals.Length; i++)
        {
            crystals[i].SetActive(false);
        }
    }

    // This method will be called when a crystal is collected
    public void CollectCrystal(GameObject crystal)
    {
        Debug.Log("Collected: " + crystal.name);

        // Find the index of the collected crystal in the array
        for (int i = 0; i < crystals.Length; i++)
        {
            if (crystals[i] == crystal)
            {
                currentCrystalIndex = i;

                // If there's a next crystal, show it
                if (currentCrystalIndex < crystals.Length - 1)
                {
                    crystals[currentCrystalIndex + 1].SetActive(true); // Show the next crystal
                }

                // Optionally, you can disable the current crystal to simulate collection
               
                crystals[currentCrystalIndex].SetActive(false);
                Destroy(crystals[currentCrystalIndex]);
                break;
            }
        }
    }
}
