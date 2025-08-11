using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField]
    private HealthController _healthController;

    private int _collisions = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMovement>())
        {
            HealthController healthController = collision.GetComponent<HealthController>();
            float maxHealth = healthController.MaximumHealth;
            healthController.TakeDamage(maxHealth);

            _collisions++;

            if (_collisions >= 3)
            {
                if (_healthController != null)
                {
                    _healthController.ForceKill();
                }
            }
        }
    }

    public void ReduceCollisions()
    {
        _collisions--;
        if (_collisions < 0)
        {
            _collisions = 0;
        }
    }
}
