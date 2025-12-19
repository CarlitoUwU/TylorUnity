using UnityEngine;

public class Controladordebala : MonoBehaviour
{
    Rigidbody bulletRb;
    public float power = 100f;
    public float lifeTime = 4f;
    public float damage = 10f;

    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.linearVelocity = transform.forward * power;
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
                playerHealth.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
