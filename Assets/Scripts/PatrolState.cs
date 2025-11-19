using UnityEngine;

public class PatrolState : IEnemyState
{
    private EnemyStatePattern _enemy;
    private int _currentPatrolIndex;
    private Transform[] _patrolPoints;
    private float _moveSpeed;
    private float _detectRange;
    private Transform _player;

    public PatrolState(EnemyStatePattern enemy)
    {
        _enemy = enemy;
        _patrolPoints = _enemy.PatrolPoints;
        _moveSpeed = _enemy.MoveSpeed;
        _player = _enemy.PlayerTrf;
        _detectRange = _enemy.DetectRange;
    }

    public void Enter()
    {

    }
    public void Exit()
    {

    }
    public void Update()
    {
        if (_patrolPoints.Length == 0)
        {
            return;
        }

        if (_patrolPoints.Length == 0)
            return;

        Transform target = _patrolPoints[_currentPatrolIndex];

        _enemy.transform.position = Vector2.MoveTowards(_enemy.transform.position,
            target.position, _moveSpeed * Time.deltaTime);

        if (Vector2.Distance(_enemy.transform.position, target.position) < 0.1f)
        {
            _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Length;
        }
        // 플레이어 감지 및 상태 변경
        if (Vector2.Distance(_enemy.transform.position, _player.position) <= _detectRange)
        {
            _enemy.SetState(new ChaseState(_enemy));
        }
    }
}
