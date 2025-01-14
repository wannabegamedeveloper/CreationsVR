using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float pushBackStrength = 2f;
    
    private Vector3 _impact;
    private const float Mass = 1f;

    private void AddImpact(Vector3 force)
    {
        var dir = force.normalized;
        _impact += dir.normalized * force.magnitude / Mass;
    }

    private void Update()
    {
        if (_impact.magnitude > 0.2)
        {
            characterController.Move(_impact * Time.deltaTime);
        }
        _impact = Vector3.Lerp(_impact, Vector3.zero, 5*Time.deltaTime);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (_impact.magnitude < .1f)
            {
                other.GetComponent<Animator>().Play("Pushing", -1, 0f);
                AddImpact(other.transform.forward * pushBackStrength);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy Fist"))
        {
            GameOverHandler.GameOver.Invoke();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.CompareTag("Wall"))
        {
            if (_impact.magnitude > .2)
                AddImpact(hit.transform.up * pushBackStrength);
        }
        
    }
}
