using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _maximumHealth;

    public float RemainingHealth
    {
        get
        {
            return _currentHealth / _maximumHealth;
        }
    }

    public UnityEvent OnDied;

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth == 0)
        {
            return;
        }

        _currentHealth -= damageAmount;

        if( _currentHealth < 0 )
        {
            _currentHealth = 0;
        }

        if(_currentHealth == 0 )
        {
            OnDied.Invoke();
        }
    }

    public void AddHealth(float amoutToAdd)
    {
        if(_currentHealth == _maximumHealth)
        {
            return;
        }

        _currentHealth += amoutToAdd;

        if( _currentHealth > _maximumHealth )
        {
            _currentHealth = _maximumHealth;
        }

    }
}
