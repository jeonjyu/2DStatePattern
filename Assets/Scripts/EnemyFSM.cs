using UnityEngine;

//적이 가질 상태의 종류
public enum EnemyState
{
    Patrol,
    Chase
}

public class EnemyFSM : MonoBehaviour
{
    //추적 대상
    public Transform _player;

    //순찰 경로
    public Transform[] _patrolPoints;

    public float _detectRange = 5f;
    public float _moveSpeed = 2f;

    private EnemyState _currentState;
    private int _currentPatrolIndex = 0;

    private void Start()
    {
        _currentState = EnemyState.Patrol;
    }

    private void Update()
    {
        switch (_currentState)
        {
            case EnemyState.Patrol:
                {
                    Patrol();
                    //플레이어 감지 체크 및 체크시 Chase상태로 전이
                    if (Vector2.Distance(transform.position, _player.position) <= _detectRange)
                    {
                        _currentState = EnemyState.Chase;
                    }
                }
                break;
            case EnemyState.Chase:
                {
                    Chase();
                    //플레이어가 범위를 벗어나면 Patrol 상태로 전이
                    if (Vector2.Distance(transform.position, _player.position) > _detectRange)
                    {
                        _currentState = EnemyState.Patrol;
                    }
                }
                break;
        }
    }   

    //순찰 로직
    private void Patrol()
    {
        if (_patrolPoints.Length == 0)
            return;

        Transform target = _patrolPoints[_currentPatrolIndex];

        transform.position = Vector2.MoveTowards(transform.position,
            target.position, _moveSpeed * Time.deltaTime);

        if(Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Length;
        }
    }

    //따라가기
    private void Chase()
    {
        Vector3 direction = (_player.position - transform.position).normalized;
        Vector3 nextPos = new Vector3(transform.position.x + direction.x * _moveSpeed * Time.deltaTime, transform.position.y);
        transform.position = nextPos;
    }
}