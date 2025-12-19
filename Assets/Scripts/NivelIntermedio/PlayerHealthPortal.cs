using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthPortal : MonoBehaviour
{
    [Header("Ajustes de Vida")]
    public float vidaMax = 100f;
    private float vidaActual;

    [Header("Referencia a la UI")]
    public Slider barraSalud;

    void Start()
    {
        vidaActual = vidaMax;
        ActualizarBarra();
    }

    public void RecibirDano(float cantidad)
    {
        vidaActual -= cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMax);
        ActualizarBarra();

        if (vidaActual <= 0)
        {
            Debug.Log("¡Tylor ha caído! Fin de la misión.");
        }
    }

    void ActualizarBarra()
    {
        if (barraSalud != null)
        {
            barraSalud.value = vidaActual / vidaMax;
        }
    }
}