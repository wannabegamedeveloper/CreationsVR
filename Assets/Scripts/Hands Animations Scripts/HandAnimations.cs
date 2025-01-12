using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimations : MonoBehaviour
{
    [SerializeField] private InputActionReference triggerTouchInput;
    [SerializeField] private InputActionReference gripInput;
    [SerializeField] private InputActionReference thumbInput;
    [SerializeField] private InputActionReference triggerInput;
    
    [SerializeField] private Animator handAnimator;

    private float _thumbLayerValue;
    private float _indexLayerValue;
    private float _thumbLayerValueCurrent;
    private float _indexLayerValueCurrent;
    private static readonly int IndexFinger = Animator.StringToHash("Fist Index");
    private static readonly int Fist = Animator.StringToHash("Fist");

    private void Start()
    {
        triggerTouchInput.action.performed += TriggerTouch;
        triggerTouchInput.action.canceled += TriggerLeave;
        
        triggerInput.action.performed += TriggerHeld;
        triggerInput.action.canceled += TriggerLeft;

        thumbInput.action.performed += ThumbTouch;
        thumbInput.action.canceled += ThumbLeave;
        
        gripInput.action.performed += Grip;
        gripInput.action.canceled += Ungrip;
    }

    private void Update()
    {
        _thumbLayerValueCurrent = Mathf.Lerp(_thumbLayerValueCurrent, _thumbLayerValue, 20f * Time.deltaTime);
        _indexLayerValueCurrent = Mathf.Lerp(_indexLayerValueCurrent, _indexLayerValue, 20f * Time.deltaTime);
        handAnimator.SetLayerWeight(3, _thumbLayerValueCurrent);
        handAnimator.SetLayerWeight(2, _indexLayerValueCurrent);
    }

    private void TriggerHeld(InputAction.CallbackContext obj)
    {
        var heldAmount = obj.ReadValue<float>();
        handAnimator.SetFloat(IndexFinger, heldAmount);
    }

    private void TriggerLeft(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat(IndexFinger, 0f);
    }

    private void ThumbTouch(InputAction.CallbackContext obj)
    {
        _thumbLayerValue = 1;
    }

    private void ThumbLeave(InputAction.CallbackContext obj)
    {
        _thumbLayerValue = 0;
    }

    private void Grip(InputAction.CallbackContext obj)
    {
        var heldAmount = obj.ReadValue<float>();
        handAnimator.SetFloat(Fist, heldAmount);
    }

    private void Ungrip(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat(Fist, 0f);
    }

    private void TriggerTouch(InputAction.CallbackContext obj)
    {
        _indexLayerValue = 1;
    }

    private void TriggerLeave(InputAction.CallbackContext obj)
    {
        _indexLayerValue = 0;
    }
}
