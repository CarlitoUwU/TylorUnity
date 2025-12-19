using UnityEngine;

public class PlayerControlPortal : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    [SerializeField] private float speed = 10f;

    [Header("Límites de Vuelo (Bordes de Pantalla)")]
    [SerializeField] private float limiteIzquierdo = -5f;
    [SerializeField] private float limiteDerecho = 15f;
    [SerializeField] private float limiteSuperior = 13f;
    [SerializeField] private float limiteInferior = 1f;

    void Update()
    {
        ProcesarMovimiento();
    }

    private void ProcesarMovimiento()
    {
        // Capturar entrada
        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoY = Input.GetAxis("Vertical");

        // Calcular nueva posición
        Vector3 desplazamiento = new Vector3(movimientoX, movimientoY, 0f) * speed * Time.deltaTime;
        Vector3 nuevaPosicion = transform.position + desplazamiento;

        // Aplicar límites
        float xLimitado = Mathf.Clamp(nuevaPosicion.x, limiteIzquierdo, limiteDerecho);
        float yLimitado = Mathf.Clamp(nuevaPosicion.y, limiteInferior, limiteSuperior);

        // Aplicar la posición final
        transform.position = new Vector3(xLimitado, yLimitado, transform.position.z);
    }
}