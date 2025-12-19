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
        float vertical = Input.GetAxis("Vertical"); // W S
        float horizontal = Input.GetAxis("Horizontal"); // A D

        if ((Mathf.Abs(vertical) > 0.1f || Mathf.Abs(horizontal) > 0.1f)
            && combustibleData.hasCombustible())
        {
            Vector3 direccion = new Vector3(horizontal, vertical, 0f);

            rb.AddForce(direccion.normalized * thrustForce * Time.deltaTime);

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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
        {
            float angulo = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;
            tf.rotation = Quaternion.Euler(0f, 0f, angulo - 90f);
        }
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
