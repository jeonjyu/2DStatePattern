using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _groundCheckDistance = 0.1f;

    private Rigidbody2D _rigid;
    private Vector2 _moveInput;
    private bool _isGround;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    //바닥 체크
    private void Update()
    {
        _isGround = Physics2D.Raycast(
            _groundChecker.position,
            Vector2.down,
            _groundCheckDistance,
            _groundLayer
            );
    }

    //입력받은 값 통해서 이동
    private void FixedUpdate()
    {
        Vector2 velocity = _rigid.linearVelocity;
        velocity.x = _moveInput.x * _moveSpeed;
        _rigid.linearVelocity = velocity;
    }

    //입력값 갱신
    public void OnMove(InputAction.CallbackContext ctx)
    {
        _moveInput = ctx.ReadValue<Vector2>();
    }

    //입력 받으면 점프
    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.started && _isGround)
        {
            Vector2 velocity = _rigid.linearVelocity;
            velocity.y = _jumpForce;
            _rigid.linearVelocity = velocity;
        }
    }
}