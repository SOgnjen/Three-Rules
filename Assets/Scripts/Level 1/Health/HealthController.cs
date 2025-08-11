using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;

    [SerializeField]
    private float _maximumHealth;

    public bool IsInvincible;
    private Animator _animator;

    public float RemainingHealth
    {
        get
        {
            return _currentHealth / _maximumHealth;
        }
    }

    public UnityEvent OnDied;

    public UnityEvent OnDamaged;

    public UnityEvent OnHealthChanged;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth == 0)
        {
            return;
        }

        if (IsInvincible)
        {
            return;
        }

        _currentHealth -= damageAmount;

        bool isHit = true;
        _animator.SetBool("IsHit", isHit);

        OnHealthChanged.Invoke();

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        if (_currentHealth == 0)
        {
            OnDied.Invoke();
        }
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void AddHealth(float amoutToAdd)
    {
        if (_currentHealth == _maximumHealth)
        {
            return;
        }

        _currentHealth += amoutToAdd;

        OnHealthChanged.Invoke();

        if (_currentHealth > _maximumHealth)
        {
            _currentHealth = _maximumHealth;
        }

    }

    public void ResetHit()
    {
        _animator.SetBool("IsHit", false);
    }

    public float MaximumHealth
    {
        get { return _maximumHealth; }
    }

    public void ForceKill()
    {
        if (_currentHealth > 0)
        {
            IsInvincible = false;
            TakeDamage(_currentHealth);
        }
    }
}
