using UnityEngine;

public class TriggerEndScene : MonoBehaviour
{
    public OgopogoAppearance ogopogoScript; // Assign the script instance
    public GameObject snake;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the "Player" tag
        {
            Debug.Log("Trigger entered by Player.");
            
            // Dynamically assign references
            ogopogoScript.SetSnake(snake);

            // Enable the script if it's not already active
            ogopogoScript.enabled = true;

            // Trigger the rising logic in OgopogoAppearance
            ogopogoScript.Start();
        }
    }
}