using UnityEngine;

public class Meteorito : MonoBehaviour
{
    public float velocidadHorizontal = 1f; // izquierda/derecha
    public float velocidadVertical = 3f;   // caída hacia abajo

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 direccion = new Vector3(velocidadHorizontal, -velocidadVertical, 0);
        rb.linearVelocity = direccion;

        // Rotación bonita (opcional)
        transform.Rotate(0, 0, 200 * Time.deltaTime);
    }
}
