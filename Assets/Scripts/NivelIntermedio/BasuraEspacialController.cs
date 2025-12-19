using UnityEngine;

public class BasuraEspacialController : MonoBehaviour
{
    [Header("Ajustes de Movimiento")]
    [SerializeField] private float velocidad = 15f;
    [SerializeField] private float tiempoVida = 6f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Velocidad lineal hacia adelante
        rb.linearVelocity = transform.up * velocidad;

        Destroy(gameObject, tiempoVida);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealthPortal salud = other.GetComponent<PlayerHealthPortal>();

            if (salud != null)
            {
                salud.RecibirDano(10f);
            }

            Destroy(gameObject);
        }
    }
}