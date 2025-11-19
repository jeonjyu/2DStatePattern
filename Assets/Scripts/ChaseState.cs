using UnityEngine;

public class ChaseState : IEnemyState
{
    private EnemyStatePattern _enemy;
    private Transform _player;
    private float _moveSpeed;
    private float _detectRange;

    public ChaseState(EnemyStatePattern enemy)
    {
        _enemy = enemy;
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
        Vector3 direction = (_player.position - _enemy.transform.position).normalized;
        Vector3 nextPos = new Vector3(_enemy.transform.position.x + direction.x * _moveSpeed * Time.deltaTime, _enemy.transform.position.y);
        _enemy.transform.position = nextPos;
        
        // 플레이어가 범위를 벗어나면 Patrol 상태로 전이
        if (Vector2.Distance(_enemy.transform.position, _player.position) > _detectRange)
        {
            // new 키워드 쓰는 게 불편하면 StatePattern에 삳ㅇ태를 만들어둬도 된다
            _enemy.SetState(new PatrolState(_enemy)); 
        }
    }
}
