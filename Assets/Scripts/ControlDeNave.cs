using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ControlDeNave : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;

    Transform tf;
    [SerializeField] private float thrustForce = 1000f;
    [SerializeField] private float rotationSpeed = 100f;

    CombustibleData combustibleData;

    public Action<float> JugadorConsumeCombustible;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        tf = GetComponent<Transform>();
        combustibleData = CombustibleData.Instance;
        combustibleData.addCombustible(100f);
    }

    private void Update()
    {
        ProcesarInput();
    }

    private void ProcesarInput()
    {
        Propulsion();
        Rotacion();
    }

    private void Propulsion()
    {
        if (Keyboard.current.spaceKey.isPressed && combustibleData.hasCombustible())
        {
            rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            combustibleData.consumeCombustible();

            JugadorConsumeCombustible?.Invoke(combustibleData.getCombustible());
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void Rotacion()
    {
        float rotacionX = 0f;
        float rotacionY = 0f;

        if (Input.GetKey(KeyCode.A))
            rotacionX = -rotationSpeed;
        else if (Input.GetKey(KeyCode.D))
            rotacionX = rotationSpeed;

        if (Input.GetKey(KeyCode.W))
            rotacionY = -rotationSpeed;
        else if (Input.GetKey(KeyCode.S))
            rotacionY = rotationSpeed;

        tf.Rotate(rotacionX * Time.deltaTime, rotacionY * Time.deltaTime, 0f, Space.Self);
    }

    private void Rotate(Vector3 axis, float rotation)
    {
        tf.Rotate(axis * rotation * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger con: " + other.gameObject.name);

        switch (other.tag)
        {
            case "BonusCombustible":
                combustibleData.bonusCombustibleAmount();
                print("Has recogido combustible...!!!");

                Destroy(other.gameObject);
                break;

            case "BasuraPoint":
                Destroy(other.gameObject);
                print("Has destruido basura espacial...!!!");
                break;
                
            case "ColisionPeligrosa":
                print("Has chocado contra un asteroide");
                break;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisi�n con: " + collision.gameObject.name);

        switch (collision.gameObject.tag)
        {
            case "ColisionSegura":
                print("Colisi�n segura");
                break;

            case "Finish":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;

            default:
                print($"Has chocado contra {collision.gameObject.name}. Game Over");
                break;
        }
    }

    public float getCombustible()
    {
        return combustibleData.getCombustible();
    }

    public float getCombustibleMaximo()
    {
        return combustibleData.getCombustibleMaximo();
    }
}
