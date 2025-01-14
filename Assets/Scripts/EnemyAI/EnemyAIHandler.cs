using UnityEngine;
using UnityEngine.AI;

public class EnemyAIHandler : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float minimumPlayerDistanceToAttack;
    
    private NavMeshAgent _agent;
    private Animator _enemyAnimator;
    private static readonly int CanPunch = Animator.StringToHash("Can Punch");
    private static readonly int GameEnd = Animator.StringToHash("Game Over");

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _enemyAnimator = GetComponent<Animator>();
        GameOverHandler.GameOver += GameOver;
    }

    private void GameOver()
    {
        _enemyAnimator.SetBool(GameEnd, true);
        _agent.enabled = false;
    }

    private void Update()
    {
        if (!_agent.enabled) return;
        _agent.destination = player.position;
        if (Vector3.Distance(transform.position, player.position) < minimumPlayerDistanceToAttack)
        {
            _enemyAnimator.SetTrigger(CanPunch);
        }
    }
}