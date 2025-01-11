using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class HapticsController : MonoBehaviour
{
    [SerializeField] private HapticImpulsePlayer hapticImpulse;
    
    public void PlayHaptic()
    {
        hapticImpulse.SendHapticImpulse(1f, .1f);
    }
}
