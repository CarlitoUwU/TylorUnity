using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    [Header("Ajustes de Movimiento")]
    public float velocidad = 20f;
    public float tiempoVida = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Usamos el eje verde del portal/meteorito para ir hacia la nave
        rb.linearVelocity = transform.up * velocidad;
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Lógica sencilla de daño
            Debug.Log("¡Impacto con jugador!");

            // Aquí llamarías a la reducción de combustible de tu nave

            Destroy(gameObject); // Desaparece al chocar
        }
    }
}