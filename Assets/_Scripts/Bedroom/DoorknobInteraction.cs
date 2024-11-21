using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorknobInteraction : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    public JournalInteraction journalInteraction; // Reference to the JournalInteraction script

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.enabled = false; // Initially disable interaction
    }

    void Update()
    {
        // Enable interaction if the journal text is enabled
        if (journalInteraction != null && journalInteraction.floatingText.enabled)
        {
            grabInteractable.enabled = true;
        }
    }

    void OnDestroy()
    {
        grabInteractable.onSelectEntered.RemoveListener(OnGrab);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        SceneManager.LoadScene("MainScene");
    }
}