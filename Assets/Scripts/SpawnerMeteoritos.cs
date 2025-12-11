using UnityEngine;

public class SpawnerMeteoritos : MonoBehaviour
{
    public GameObject prefabMeteorito;
    public float tiempoEntreMeteoritos = 2f;
    public float rangoX = 15f;
    public float alturaSpawn = 10f;

    void Start()
    {
        InvokeRepeating("SpawnMeteorito", 1f, tiempoEntreMeteoritos);
    }

    void SpawnMeteorito()
    {
        Vector3 posicion = new Vector3(
            Random.Range(-rangoX, rangoX),
            alturaSpawn,
            0f
        );

        Instantiate(prefabMeteorito, posicion, Quaternion.identity);
    }
}
