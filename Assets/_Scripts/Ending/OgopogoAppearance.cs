using UnityEngine;
/*
 * This Script handles the appearing of Ogopogo!
 * Whenever invoked, Ogopogo starts rising and animation is played :)
 */

public class OgopogoAppearance : MonoBehaviour
{
    public GameObject snake; // Assign the snake's transform
    public float riseHeight = 4f; // How high the snake rises above its current position
    public float riseSpeed = 2f; // Speed of rising
    private float delayBeforeRising = 4f; // Delay before the snake starts appearing

    private Vector3 targetPosition;
    private bool isRising = false;

    private Animator animator; // Reference to the Animator component

    public void Start()
    {
        Debug.Log("Ogopogo Appearance Start");
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
            if (snake.transform.position == targetPosition)
            {
                isRising = false;
                PlayIdleAnimation(); // Trigger the idle animation
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
            Debug.Log("Ogopogo Appearance Play Idle Animation");
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
