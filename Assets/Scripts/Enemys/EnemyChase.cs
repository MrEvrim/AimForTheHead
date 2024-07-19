using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public float attackRange = 1.5f;
    public int maxHealth = 3;
    private int currentHealth;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isDead)
        {
            Vector3 playerPosition = player.position;

            transform.LookAt(playerPosition);

            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);


            float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);
        }
    }
    public void TakeDamage(int damageAmount)
    {
        if (!isDead)
        {
            currentHealth -= damageAmount;

            if (currentHealth <= 0)
            {
                Die(); // Eğer düşmanın canı sıfır veya daha azsa, düşmanı yok et
            }
        }
    }

    void Die()
    {
        isDead = true;
        Destroy(gameObject, 3f);
    }
}