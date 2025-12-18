using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarraCombustible : MonoBehaviour
{
    
    [SerializeField] private Slider barraCombustible;
    [SerializeField] private ControlDeNave nave;
    [SerializeField] private TextMeshProUGUI textoCombustible;
    void Start()
    {
        if (nave == null)
            nave = FindFirstObjectByType<ControlDeNave>();

        try
        {
            nave.JugadorConsumeCombustible += ActualizarBarraCombustible;
        }
        catch (Exception ex)
        {
            Debug.LogWarning($"BarraCombustible: error al suscribirse al evento JugadorConsumeCombustible - {ex.Message}");
        }

        IniciarBarraCombustible((int)nave.getCombustibleMaximo(), (int)nave.getCombustible());
        ActualizarBarraCombustible(nave.getCombustible());
    }

    private void OnDisable()
    {
         if (nave != null)
        nave.JugadorConsumeCombustible -= ActualizarBarraCombustible;
    }

    private void IniciarBarraCombustible(int combustibleMaximo, int combustibleActual)
    {
  
        if (combustibleMaximo <= 0)
        {
            Debug.LogWarning($"BarraCombustible: combustibleMaximo es {combustibleMaximo}. Ajustando a 1 para evitar división por cero en Slider.");
            combustibleMaximo = 1;
        }

        barraCombustible.maxValue = combustibleMaximo;

        var valor = Mathf.Clamp(combustibleActual, 0, barraCombustible.maxValue);
        barraCombustible.value = valor;

        if (textoCombustible != null)
            textoCombustible.text = ((int)valor).ToString("000");
    }

    private void ActualizarBarraCombustible(float combustibleActual)
    {
        if (barraCombustible == null)
        {
            Debug.LogError("BarraCombustible: intento de actualizar pero 'barraCombustible' es null.");
            return;
        }

        var valor = Mathf.Clamp(combustibleActual, 0, barraCombustible.maxValue);
        barraCombustible.value = valor;

        if (textoCombustible != null)
            textoCombustible.text = ((int)valor).ToString("000");
    }
}
