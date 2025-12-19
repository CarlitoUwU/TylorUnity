using UnityEngine;

public class CameraFollow2_5D : MonoBehaviour
{
    public Transform objetivo;

    [Header("Suavizado")]
    public float velocidadCamara = 0.1f;
    public Vector3 desplazamiento;

    [Header("Límites del nivel")]
    public Vector2 minBounds;
    public Vector2 maxBounds;

    private void LateUpdate()
    {
        if (objetivo == null) return;

        Vector3 posicionDeseada = objetivo.position + desplazamiento;

        // Limitar cámara
        posicionDeseada.x = Mathf.Clamp(posicionDeseada.x, minBounds.x, maxBounds.x);
        posicionDeseada.y = Mathf.Clamp(posicionDeseada.y, minBounds.y, maxBounds.y);

        Vector3 posicionSuavizada = Vector3.Lerp(
            transform.position,
            posicionDeseada,
            velocidadCamara
        );

        transform.position = posicionSuavizada;
    }
}
