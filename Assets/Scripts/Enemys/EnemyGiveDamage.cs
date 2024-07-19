using UnityEngine;

public class EnemyGiveDamage : MonoBehaviour
{
    public int damageAmount = 1;
    private int damageCount = 0; 
    private const int maxDamageCount = 10; 
    private bool hasDealtDamage = false;

    void OnCollisionEnter(Collision collision)
    {
        if (!hasDealtDamage && collision.gameObject.CompareTag("Player") && damageCount < maxDamageCount)
        {
            // Player nesnesine zarar ver
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                hasDealtDamage = true; 
                damageCount++; 
            }
        }
    }
}