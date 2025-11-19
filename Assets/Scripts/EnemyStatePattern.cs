using UnityEngine;

public class EnemyStatePattern : MonoBehaviour
{
    public Transform _player;
    public Transform[] _patrolPoints;
    public float _detectRange = 5f;
    public float _moveSpeed = 2f;

    private IEnemyState _currentState;
    public Transform[] PatrolPoints => _patrolPoints;
    public float MoveSpeed => _moveSpeed;
    public float DetectRange => _detectRange;
    public Transform PlayerTrf => _player;

    private void Start()
    {
        // 이걸로 처음에 상태를 지정해줘야 게임 안에서 상태 변화가 일어날 수 있다
        SetState(new PatrolState(this));
    }

    private void Update()
    {
        _currentState.Update();
    }
    public void SetState(IEnemyState newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
}
