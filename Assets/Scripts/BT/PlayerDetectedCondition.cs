using UnityEngine;

// 플레이어를 찾은 상태
public class PlayerDetectedCondition : ConditionNode
{
    private Transform _enemy;
    private Transform _player;
    private float _detectionRange;

    public PlayerDetectedCondition(Transform enemy, Transform player, float detectionRange)
    {
        _enemy = enemy;
        _player = player;
        _detectionRange = detectionRange;
    }

    public override NodeState Tick()
    {
        float distance = Vector2.Distance(_enemy.position, _player.position);
        return distance <= _detectionRange ? NodeState.Success : NodeState.Failure;
        
    }
}
