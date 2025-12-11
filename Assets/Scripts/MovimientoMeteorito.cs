using UnityEngine;

public class Meteorito : MonoBehaviour
{
    public float velocidadHorizontal = 1f; // para que caiga diagonal
    public float velocidadVertical = 3f;   // ca�da

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Movimiento diagonal
        Vector3 direccion = new Vector3(velocidadHorizontal, -velocidadVertical, 0);
        rb.linearVelocity = direccion;
    }
}
