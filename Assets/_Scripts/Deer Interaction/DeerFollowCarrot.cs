using System.Collections;
using UnityEngine;

public class DeerFollowCarrot : MonoBehaviour
{
    public GameObject deer;
    public GameObject carrot;         // Reference to the carrot GameObject
    [SerializeField] Transform carrotOriginalPosition;
    public float detectionRange = 5.0f; // Range within which the deer detects the carrot
    public float followSpeed = 3.0f;  // Speed of the deer while following the carrot

    private DeerMoveBetweenPoints deerMovement;

    void Start()
    {
        // Get reference to the DeerMovement script
        deerMovement = GetComponent<DeerMoveBetweenPoints>();
    }

    void Update()
    {
        if (carrot == null || deerMovement == null || !carrot.activeSelf)
        {
            return;
        }

        // Check if the carrot is close enough
        float distanceToCarrot = Vector3.Distance(deer.transform.position, carrot.transform.position);

        if (distanceToCarrot <= detectionRange && distanceToCarrot >= 1)
        {
            // Start following the carrot
            deerMovement.SetFollowingCarrot(true);
            FollowCarrot();
        }
        else if (distanceToCarrot < 1)
        {
            //Destroy(carrot);  // Destroy the carrot object
            Debug.Log("Carrot is eaten by the deer");
            carrot.SetActive(false);
            StartCoroutine(ResetCarrot());

            deerMovement.SetFollowingCarrot(false);
        }
        else
        {
            // Stop following the carrot and resume original movement
            deerMovement.SetFollowingCarrot(false);
        }
    }

    private IEnumerator ResetCarrot()
    {
        // Wait for 8 seconds before regenerating the carrot
        yield return new WaitForSeconds(8f);

        carrot.transform.position = carrotOriginalPosition.position;
        carrot.SetActive(true);
    }


    void FollowCarrot()
    {
        // Move the deer towards the carrot's position
        Vector3 direction = (carrot.transform.position - deer.transform.position).normalized;
        deer.transform.position = Vector3.MoveTowards(deer.transform.position, carrot.transform.position, followSpeed * Time.deltaTime);

        // Rotate the deer to face the carrot
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            deer.transform.rotation = Quaternion.Slerp(deer.transform.rotation, targetRotation, followSpeed * Time.deltaTime);
        }
    }
}
