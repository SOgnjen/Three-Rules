using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Rigidbody2D _rigidbody;
    private PlayerAwarenessController _playerAwarenessController;
    private Vector2 _targetDirection;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        if(_playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }
        else
        {
            _targetDirection = _playerAwarenessController.DirectionToCrystal;
        }
    }

    private void RotateTowardsTarget()
    {
        if(_targetDirection == Vector2.zero)
        {
            return;
        }
        else
        {
            if (_targetDirection.x < 0)
                _spriteRenderer.flipX = true;
            else if (_targetDirection.x > 0)
                _spriteRenderer.flipX = false;
        }
    }

    private void SetVelocity()
    {
        if(_targetDirection == Vector2.zero)
        {
            _rigidbody.linearVelocity = Vector2.zero;
        }
        else
        {
            _rigidbody.linearVelocity = _targetDirection.normalized * _speed;
        }
    }

    public void StopMovement()
    {
        _rigidbody.linearVelocity = Vector2.zero;
    }
}
