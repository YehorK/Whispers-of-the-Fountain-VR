using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorknobInteraction : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnGrab);
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