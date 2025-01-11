using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GrabbableObject : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable grabInteractable;

    private void Start()
    {
        Application.targetFrameRate = 120;
    }

    private Rigidbody _rb;

    private void OnCollisionEnter(Collision collision)
    {
        grabInteractable.movementType = XRBaseInteractable.MovementType.VelocityTracking;
    }

    private void OnCollisionExit(Collision other)
    {
        grabInteractable.movementType = XRBaseInteractable.MovementType.Instantaneous;
    }
}
