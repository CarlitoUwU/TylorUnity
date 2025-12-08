using System;
using UnityEngine;
using UnityEngine.UI;

public class BarraCombustible : MonoBehaviour
{
    
    [SerializeField] private Slider barraCombustible;
    [SerializeField] private ControlDeNave nave;
    void Start()
    {
        nave = FindFirstObjectByType<ControlDeNave>();

        nave.JugadorConsumeCombustible += ActualizarBarraCombustible;

        IniciarBarraCombustible((int)nave.getCombustibleMaximo(), (int)nave.getCombustible());
    }

    private void OnDisable()
    {
        nave.JugadorConsumeCombustible -= ActualizarBarraCombustible;
    }

    private void IniciarBarraCombustible(int combustibleMaximo, int combustibleActual)
    {
        barraCombustible.maxValue = combustibleMaximo;
        barraCombustible.value = combustibleActual;
    }

    private void ActualizarBarraCombustible(float combustibleActual)
    {
        barraCombustible.value = combustibleActual;
    }
}
