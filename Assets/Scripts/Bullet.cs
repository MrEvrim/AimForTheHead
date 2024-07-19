using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damageAmount = 1;
    public Rigidbody rb;

    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoints"))
        {
            // Mermiyi yok et
            Destroy(other.gameObject);
        }
        else
        {
            EnemyChase enemy = other.GetComponent<EnemyChase>(); // Çarpılan nesnenin EnemyChase bileşenini al

            if (enemy != null)
            {
                enemy.TakeDamage(damageAmount); // Düşmana hasar ver
            }
            Destroy(gameObject);
        }
    }
}