using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimations : MonoBehaviour
{
    [SerializeField] private InputActionReference triggerTouchInput;
    [SerializeField] private InputActionReference gripInput;
    
    [SerializeField] private Animator handAnimator;
    
    private void Start()
    {
        triggerTouchInput.action.performed += TriggerTouch;
        triggerTouchInput.action.canceled += TriggerLeave;
        
        gripInput.action.performed += Grip;
        gripInput.action.canceled += Ungrip;
    }

    private void Grip(InputAction.CallbackContext obj)
    {
        var heldAmount = obj.ReadValue<float>();
        print(heldAmount);
        handAnimator.SetFloat("Fist", heldAmount);
    }

    private void Ungrip(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat("Fist", 0f);
    }

    private void TriggerTouch(InputAction.CallbackContext obj)
    {
        handAnimator.SetLayerWeight(2, 1);
    }

    private void TriggerLeave(InputAction.CallbackContext obj)
    {
        handAnimator.SetLayerWeight(2, 0);
    }
}
