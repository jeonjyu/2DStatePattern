using UnityEngine;

public class ChasePlayerAction : ActionNode
{
    private Transform _enemy;
    private Transform _player;
    private float _moveSpeed;

    public ChasePlayerAction(Transform enemy, Transform player, float moveSpeed)
    {
        _enemy = enemy;
        _player = player;
        _moveSpeed = moveSpeed;
    }

    public override NodeState Tick()
    {
        Vector3 direction = (_player.position - _enemy.position).normalized;
        _enemy.position += direction * _moveSpeed * Time.deltaTime;
        return NodeState.Running;
    }
}
