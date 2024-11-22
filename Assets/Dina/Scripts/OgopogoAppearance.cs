using UnityEngine;

public class OgopogoAppearance : MonoBehaviour
{
    public Transform fountainTop; // Assign the fountain's water surface level
    private float riseHeight = 2f; // How high the snake rises above the water
    private float riseSpeed = 2f; // Speed of rising
    private float delayBeforeRising = 1f; // Delay before the snake starts appearing

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool isRising = false;

    private Animator animator; // Reference to the Animator component

    void Start()
    {
        // Get the Animator component attached to the snake
        animator = GetComponent<Animator>();

        // Set initial and target positions
        startPosition = transform.position;
        targetPosition = fountainTop.position + Vector3.up * riseHeight;

        // Start the rising process after a delay
        Invoke(nameof(StartRising), delayBeforeRising);
    }

    void Update()
    {
        if (isRising)
        {
            // Smoothly move the snake upwards
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, riseSpeed * Time.deltaTime);

            // Stop when the target position is reached and start the idle animation
            if (transform.position == targetPosition)
            {
                isRising = false;
                PlayIdleAnimation(); // Trigger the idle animation
            }
        }
    }

    private void StartRising()
    {
        isRising = true;
    }

    private void PlayIdleAnimation()
    {
        if (animator != null)
        {
            // Play the idle animation (using the animation state name)
            animator.Play("SnakeArmature|Snake_Idle");
        }
        else
        {
            Debug.LogWarning("Animator not assigned or missing on the snake object.");
        }
    }
}
