using UnityEngine;

public class OgopogoAppearance : MonoBehaviour
{
    public GameObject snake; // Assign the snake's transform
    private float riseHeight = 4f; // How high the snake rises above its current position
    private float riseSpeed = 2f; // Speed of rising
    private float delayBeforeRising = 1f; // Delay before the snake starts appearing

    private Vector3 targetPosition;
    private bool isRising = false;

    private Animator animator; // Reference to the Animator component

    public void Start()
    {
        // Get the Animator component attached to the snake
        animator = snake.GetComponent<Animator>();

        // Set the target position to rise upwards from the snake's current position (keeping X and Z fixed)
        targetPosition = new Vector3(snake.transform.position.x, 
            snake.transform.position.y + riseHeight, snake.transform.position.z);

        // Start the rising process after a delay
        Invoke(nameof(StartRising), delayBeforeRising);
    }

    void Update()
    {
        if (isRising)
        {
            // Smoothly move the snake upwards (along the Y axis only)
            snake.transform.position = Vector3.MoveTowards(snake.transform.position, targetPosition, riseSpeed * Time.deltaTime);

            // Stop when the target position is reached and start the idle animation
            if (snake.transform.position == targetPosition)
            {
                PlayIdleAnimation(); // Trigger the idle animation
                isRising = false;
            }
        }
    }

    // Start the rising motion
    public void StartRising()
    {
        isRising = true;
    }

    // Play the idle animation
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

    // Set the snake Transform (can be assigned via script)
    public void SetSnake(GameObject snake)
    {
        this.snake = snake;
    }
}
