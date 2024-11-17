using UnityEngine;

public class BarrierController : MonoBehaviour
{
    public GameObject player;
    public GameObject deer;         // Reference to the deer
    public GameObject carrot;       // Reference to the carrot
    public GameObject barrier;      // Reference to the barrier (the object you want to disappear)

    public Vector3 offset = new Vector3(1f, 0f, 0f);  // Offset to reposition player away from barrier


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Move the player slightly back (away from the barrier)
            player.transform.position -= offset;
            Debug.Log("Player is blocked by the barrier!");
        }

        // When the deer enters the barrier, make the barrier disappear
        if (other.gameObject == deer)
        {
            // Disable the barrier
            if (barrier != null)
            {
                barrier.SetActive(false);  // Or use Destroy(barrier) if you want to remove it permanently
                Debug.Log("Deer has entered, barrier disappears!");
            }
        }
    }
}
