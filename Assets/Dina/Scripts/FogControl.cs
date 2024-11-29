using UnityEngine;

public class FogControl : MonoBehaviour
{
    private Vector3 lastPosition;
    private float currentFogDensity;

    public float fogDensityWhenRising = 0.03f;   // Fog density when rising
    public float fogDensityWhenIdle = 0.01f;     // Fog density when idle or falling
    public float fogTransitionSpeed = 2f;         // Speed of the fog transition
    private GameObject snakeObject;
    
    void Start()
    {
        snakeObject = GameObject.FindWithTag("snake");
        Debug.Log(snakeObject != null ? "Snake found." : "Snake not found. Check hierarchy or name.");
        // Enable fog and set initial density to idle
        RenderSettings.fog = true;
        currentFogDensity = fogDensityWhenIdle;
        RenderSettings.fogDensity = currentFogDensity;

        // Store the initial position of the snake
        lastPosition = snakeObject.transform.position;
    }

    void Update()
    {

        // Check if the snake is rising by comparing the Y-position
        if (snakeObject.transform.position.y > lastPosition.y)
        {
            // Transition to rising fog density smoothly
            SetFogDensity(fogDensityWhenRising);
        }
        else
        {
            // Transition back to idle fog density smoothly (or falling)
            SetFogDensity(fogDensityWhenIdle);
            // Debug.Log("Current fog density: " + RenderSettings.fogDensity);
        }

        // Update the last position to the current one for the next frame
        lastPosition = transform.position;
    }

    // Smoothly transition the fog density to the target value using Lerp
    private void SetFogDensity(float targetDensity)
    {
        // Smooth transition with Mathf.Lerp
        currentFogDensity = Mathf.Lerp(currentFogDensity, targetDensity, Time.deltaTime * fogTransitionSpeed);
        RenderSettings.fogDensity = currentFogDensity;
    }
}