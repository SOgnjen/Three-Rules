using UnityEngine;

public class Crystal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMovement>())
        {
            HealthController healthController = collision.GetComponent<HealthController>();
            float maxHealth = healthController.MaximumHealth;
            healthController.TakeDamage(maxHealth);
        }
    }
}
