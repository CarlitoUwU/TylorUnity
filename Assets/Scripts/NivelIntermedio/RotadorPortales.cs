using UnityEngine;

public class RotadorPortales : MonoBehaviour
{
    [Header("Configuración de Rotación")]
    public float velocidadMinima = 30f;
    public float velocidadMaxima = 80f;

    private float velocidadActual;
    private int direccion;

    void Start()
    {
        // Velocidad aleatoria dentro del rango
        velocidadActual = Random.Range(velocidadMinima, velocidadMaxima);

        // Sentido aleatorio
        direccion = (Random.value > 0.5f) ? 1 : -1;

        Debug.Log("Iniciando Nivel 8: Rotación a " + velocidadActual + " con dirección " + direccion);
    }

    void Update()
    {
        transform.Rotate(0, 0, velocidadActual * direccion * Time.deltaTime);
    }
}