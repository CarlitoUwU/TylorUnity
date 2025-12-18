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
        nave = FindFirstObjectByType<ControlDeNave>();

        nave.JugadorConsumeCombustible += ActualizarBarraCombustible;

        IniciarBarraCombustible((int)nave.getCombustibleMaximo(), (int)nave.getCombustible());
        ActualizarBarraCombustible(nave.getCombustible());
    }

    private void OnDisable()
    {
        nave.JugadorConsumeCombustible -= ActualizarBarraCombustible;
    }

    private void IniciarBarraCombustible(int combustibleMaximo, int combustibleActual)
    {
        barraCombustible.maxValue = combustibleMaximo;
        barraCombustible.value = combustibleActual;
        textoCombustible.text = ((int)combustibleActual).ToString("000"); ;
    }

    private void ActualizarBarraCombustible(float combustibleActual)
    {
        barraCombustible.value = combustibleActual;
        textoCombustible.text = ((int)combustibleActual).ToString("000"); ;
    }
}
