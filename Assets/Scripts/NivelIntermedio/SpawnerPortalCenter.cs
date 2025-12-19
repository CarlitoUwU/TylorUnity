using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerPortalCenter : MonoBehaviour
{
    public GameObject meteoritePrefab;
    public Transform[] portales;
    public float tiempoEntreFilas = 2.5f;
    [Range(1, 3)] public int meteoritosPorFila = 2;

    void Start()
    {
        // Solo empezamos si hay al menos un portal asignado
        if (portales != null && portales.Length > 0)
        {
            StartCoroutine(GenerarFilasDeMeteoritos());
        }
    }

    IEnumerator GenerarFilasDeMeteoritos()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoEntreFilas);

            // Creamos una lista dinámica basada en cuántos portales pusiste en el Inspector
            List<int> indicesDisponibles = new List<int>();
            for (int i = 0; i < portales.Length; i++) indicesDisponibles.Add(i);

            // Calculamos cuántos disparar (no podemos disparar más de los que tenemos)
            int cantidadADisparar = Mathf.Min(meteoritosPorFila, portales.Length);

            for (int i = 0; i < cantidadADisparar; i++)
            {
                int randomIdx = Random.Range(0, indicesDisponibles.Count);
                int portalElegido = indicesDisponibles[randomIdx];

                Instantiate(meteoritePrefab, portales[portalElegido].position, portales[portalElegido].rotation);

                indicesDisponibles.RemoveAt(randomIdx);
            }
        }
    }
}