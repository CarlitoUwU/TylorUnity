using UnityEngine;

public class BossController : MonoBehaviour
{
    public float maxHealth = 1000f;
    public float currentHealth;
    public BossMusicController bossMusic;
    public BossAudio bossAudio;

    [Header("Círculos")]
    public GameObject primerCirculo;
    public GameObject segundoCirculo;
    public GameObject tercerCirculo;

    [Header("Rotadores")]
    public CircleRotator rot1;
    public CircleRotator rot2;
    public CircleRotator rot3;

    void Start()
    {
        currentHealth = maxHealth;

        // Iniciar música del jefe
        if (bossMusic != null)
            bossMusic.PlayBossMusic();

        // Fase inicial
        segundoCirculo.SetActive(false);
        tercerCirculo.SetActive(false);
    }

    void Update()
    {
        float hpPercent = currentHealth / maxHealth;

        // FASE 1
        if (hpPercent > 0.66f)
        {
            rot1.SetSpeed(20f);
        }
        // FASE 2
        else if (hpPercent > 0.33f)
        {
            segundoCirculo.SetActive(true);
            rot1.SetSpeed(30f);
            rot2.SetSpeed(-40f);
        }
        // FASE 3
        else
        {
            tercerCirculo.SetActive(true);
            rot1.SetSpeed(50f);
            rot2.SetSpeed(-60f);
            rot3.SetSpeed(80f);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (bossAudio != null)
            bossAudio.PlayHit();


        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        bossMusic.StopBossMusic();

        Destroy(gameObject, 2f);

    }
}
