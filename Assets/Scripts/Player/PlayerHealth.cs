using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject heli;
    public GameObject mainPlayer;
    public GameObject DeadCas;
    public int maxHealth = 10000000;
    private int currentHealth;
    public float invulnerabilityTime = 10f; // Kısa bir koruma süresi (saniye)
    private bool isInvulnerable = false;
    private float invulnerabilityTimer = 0f;
    private int deathCount = 10;
    public int RealHealth;
    public Text HealthTxt;

    void Start()
    {
        currentHealth = maxHealth; // Başlangıçta oyuncunun canını maksimum olarak ayarla
    }

    void Update()
    {
        RealHealth = deathCount;
        HealthTxt.text = RealHealth.ToString();
        if (RealHealth == 0)
        {
            Time.timeScale = 0;
            DeadCas.SetActive(true);
            mainPlayer.SetActive(false);
            heli.SetActive(false);


        }

        if (isInvulnerable)
        {
            invulnerabilityTimer += Time.deltaTime;

            if (invulnerabilityTimer >= invulnerabilityTime)
            {
                isInvulnerable = false;
                invulnerabilityTimer = 0f;
            }
        }
    }
    public void TakeDamage(int damageAmount)
    {
        if (isInvulnerable)
        {
            return;
        }
        currentHealth -= damageAmount;

        isInvulnerable = true;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        deathCount--;
    }
}