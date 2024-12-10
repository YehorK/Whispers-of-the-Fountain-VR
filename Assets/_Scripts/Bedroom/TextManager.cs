using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI storyText;
    public InputActionReference actionReference;
    public AudioSource audioSource; // Add this field
    private List<string> storyLines;
    private int currentLineIndex = 0;
    private bool isFading = false;

    void Start()
    {
        storyLines = new List<string>
        {
            "What a lovely morning! Press Right Trigger to continue.",
            "Its the weekend, and you have nothing to do. Press Right Trigger to continue.",
            "But what's that on the chair? You don't remember having any old books like that at home... Press Right Trigger.",
            "Did it just talk to me? \nControls: Walk with the left joystick. \nTeleport by holding the right joystick upwards and pointing your right controller to where you'd like to go. \nGrab items using the grip button on your left or right controller.\nWalk or Teleport to the journal and grab it with the grip button"
        };
        UpdateText();
        actionReference.action.performed += OnActionPerformed;
    }

    void OnDestroy()
    {
        actionReference.action.performed -= OnActionPerformed;
    }

    private void OnActionPerformed(InputAction.CallbackContext context)
    {
        if (!isFading)
        {
            currentLineIndex++;
            if (currentLineIndex < storyLines.Count)
            {
                if (currentLineIndex == 3) // Check if it's the new text
                {
                    audioSource.Play(); // Play the sound
                    StartCoroutine(ShowTextAfterDelay(3f)); // Show the text after 3 seconds
                }
                else
                {
                    UpdateText();
                }
            }
        }
    }

    void UpdateText()
    {
        storyText.text = storyLines[currentLineIndex];
    }

    private IEnumerator ShowTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        UpdateText();
        StartCoroutine(HideTextAfterDelay(12f)); // Hide the text after 12 seconds
    }

    private IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        storyText.text = ""; // Clear the text
    }
}
