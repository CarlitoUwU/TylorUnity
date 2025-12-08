using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlDeNave : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    private float combustible = 100.0f;
    private const int consumoPorSegundo = 25;
    private const int combustibleMaximo = 100;
    private const int bonusCombustible = 50;
    public Action<float> JugadorConsumeCombustible;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        ProcesarInput();
    }

    public float getCombustible()
    {
        return combustible;
    }

    public float getCombustibleMaximo()
    {
        return combustibleMaximo;
    }

    private void ProcesarInput()
    {
        Propulsion();
        Rotacion();
        Debug.Log("Combustible: " + combustible);
    }
    private void Propulsion()
    {
        // --- PROPULSIÓN ---
        if (Keyboard.current.spaceKey.isPressed && combustible > 0)
        {
            rb.AddRelativeForce(Vector3.up);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            combustible -= consumoPorSegundo * Time.deltaTime;
            if (combustible <= 0) combustible = 0;

            JugadorConsumeCombustible?.Invoke(combustible);
        }
        else
        {
            audioSource.Stop();
        }
    }
    private void Rotacion() {
        // --- ROTACIÓN ---
        if (Keyboard.current.dKey.isPressed)
        {
            var rotarDerecha = transform.rotation;
            rotarDerecha.z -= Time.deltaTime * 1; // velocidad de rotación
            transform.rotation = rotarDerecha;
        }
        else if (Keyboard.current.aKey.isPressed)
        {
            var rotarIzquierda = transform.rotation;
            rotarIzquierda.z += Time.deltaTime * 1; // velocidad de rotación
            transform.rotation = rotarIzquierda;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "ColisionSegura":
                print("Colision segura");
                break;
            case "BonusCombustible":
                combustible += bonusCombustible;
                if (combustible > combustibleMaximo) combustible = combustibleMaximo;
                JugadorConsumeCombustible?.Invoke(combustible);
                Destroy(collision.gameObject);
                break;
            default:
                print("Muerto...!!!");
                break;
        }
    }

}
