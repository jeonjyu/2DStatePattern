using System.Collections.Generic;
using UnityEngine;

// 오브젝트에 붙일거니까 MonoBehavior를 상속
public class EnemyAI : MonoBehaviour
{

    public Transform _player;
    public Transform[] _waypoints;
    public float _detectionRange = 5f;
    public float _moveSpeed = 2f;

    private BTNode _root;

    private void Start()
    {
        // 트리 구성
        // 지금은 Selector가 최상단
        _root = new SelectorNode(new List<BTNode>
        {
            // And로 동작할 SquenceNode
            new SequenceNode(new List<BTNode>
            {
                // 플레이어 탐색 컨디션과 탐색 성공 시 수행할 추격 액션
                new PlayerDetectedCondition(transform, _player, _detectionRange),
                new ChasePlayerAction(transform, _player, _moveSpeed)
            }),
            // 순찰 액션
            new PatrolAction(transform, _waypoints, _moveSpeed)
        });
    }

    private void Update()
    {
        _root.Tick();
    }
}
