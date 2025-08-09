using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject _attackPrefab;
    [SerializeField]
    private float _attackSpeed;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void FireBullet()
    {
        Vector3 mouseWorldPos = _mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorldPos.z = 0f;

        Vector2 direction = (mouseWorldPos - transform.position).normalized;

        GameObject attack = Instantiate(_attackPrefab, transform.position, Quaternion.identity);

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
