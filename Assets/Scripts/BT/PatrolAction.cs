using UnityEngine;

public class PatrolAction : ActionNode
{
    private Transform _enemy;
    private Transform[] _waypoints;
    private float _moveSpeed;
    private int _currentWayIndex = 0;

    public PatrolAction(Transform enemy, Transform[] waypoints, float moveSpeed)
    {
        _enemy = enemy;
        _waypoints = waypoints;
        _moveSpeed = moveSpeed;
    }

    public override NodeState Tick()
    {
        if (_waypoints.Length == 0)
            return NodeState.Failure;

        Vector3 target = _waypoints[_currentWayIndex].position;
        _enemy.position = Vector3.MoveTowards(_enemy.position, target, _moveSpeed * Time.deltaTime);

        if(Vector3.Distance(_enemy.position, target) < 0.1f)
        {
            // 인덱스가 길이를 넘지 않도록
            _currentWayIndex = (_currentWayIndex + 1) % _waypoints.Length;
        }

        return NodeState.Running;
    }
}
