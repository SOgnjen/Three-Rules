using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    [SerializeField]
    private float _speed;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;
    [SerializeField]
    private float _rotationSpeed;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        UpdateSpriteDirection();
    }

    private void SetPlayerVelocity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
                    _smoothedMovementInput,
                    _movementInput,
                    ref _movementInputSmoothVelocity,
                    0.1f);

        _rigidbody.linearVelocity = _smoothedMovementInput * _speed;
    }

    private void UpdateSpriteDirection()
    {
        if (_smoothedMovementInput.x > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_smoothedMovementInput.x < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}
