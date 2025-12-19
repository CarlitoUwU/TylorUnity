using UnityEngine;
using System.Collections;

public class SpawnerBasuraPortales : MonoBehaviour
{
    [Header("Configuración del Objeto")]
    [SerializeField] private GameObject basuraPrefab;
    [SerializeField] private Transform[] portales;

    [Header("Ritmo de Lanzamiento")]
    [SerializeField] private float tiempoMinimo = 1.5f;
    [SerializeField] private float tiempoMaximo = 4.0f;

    void Start()
    {
        // Verificación de los portales
        if (portales != null && portales.Length > 0)
        {
            StartCoroutine(GenerarBasuraIntermitente());
        }
        else
        {
            Debug.LogWarning("¡Atención! No has asignado los portales en el Inspector.");
        }
    }

    IEnumerator GenerarBasuraIntermitente()
    {
        while (true)
        {
            // Esperar un tiempo aleatorio para que no sea predecible
            float espera = Random.Range(tiempoMinimo, tiempoMaximo);
            yield return new WaitForSeconds(espera);

            // Lanzar basura desde los 4 portales
            foreach (Transform portal in portales)
            {
                if (portal != null)
                {
                    // Instanciamos la basura en la posición y rotación del portal
                    Instantiate(basuraPrefab, portal.position, portal.rotation);
                }
            }
        }
    }
}