using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject _attackPrefab;
    [SerializeField]
    private float _attackSpeed;
    private Camera _mainCamera;
    public Vector2 _shootOffsetRight = new Vector2(0.23f, -0.12f);
    public Vector2 _shootOffsetLeft = new Vector2(-0.23f, -0.12f);
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _mainCamera = Camera.main;
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void FireBullet()
    {
        Vector3 mouseWorldPos = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorldPos.z = 0f;

        Vector2 direction = (mouseWorldPos - transform.position).normalized;

        Vector2 shootPos = (Vector2)transform.position + (_spriteRenderer.flipX ? _shootOffsetLeft : _shootOffsetRight);

        GameObject attack = Instantiate(_attackPrefab, shootPos, Quaternion.identity);

        Rigidbody2D rigidbody = attack.GetComponent<Rigidbody2D>();
        if (rigidbody != null)
        {
            rigidbody.linearVelocity = direction * _attackSpeed;
        }

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        attack.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void OnAttack(InputValue inputValue)
    {
        if(inputValue.isPressed)
        {
                FireBullet();

        }
    }
}
