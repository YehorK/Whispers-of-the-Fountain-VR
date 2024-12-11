using System.Collections;
using UnityEngine;

public class CarrotInstantiate : MonoBehaviour
{
    [SerializeField] GameObject carrotPrefab; // The original carrot prefab to instantiate
    [SerializeField] private Transform originalPositionObject; // Reference to the empty GameObject
    private Vector3 originalPosition; // To store the carrot's original position

    void Start()
    {
        // Store the position of the empty GameObject responsible for the original position
        if (originalPositionObject != null)
        {
            originalPosition = originalPositionObject.position;
        }
        else
        {
            Debug.LogWarning("originalPositionObject is not assigned.");
        }
    }

    public void IsCarrotDestroyed()
    {
        // Start the regeneration coroutine when this GameObject is destroyed
        StartCoroutine(RegenerateCarrot());
    }

    private IEnumerator RegenerateCarrot()
    {
        // Wait for 8 seconds before regenerating the carrot
        yield return new WaitForSeconds(8f);

        // Instantiate the carrot prefab at the original position
        Instantiate(carrotPrefab, originalPosition, Quaternion.identity);
    }
}
