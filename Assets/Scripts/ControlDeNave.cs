using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ControlDeNave : MonoBehaviour
{
    public static ControlDeNave Instance;

    Rigidbody rb;
    AudioSource audioSource;

    public static float combustibleSobrante = 0f;

    [SerializeField] private float combustible = 0.0f;
    [SerializeField] private int combustibleMaximo = 100;

    private const int combustibleBase = 100;
    private const int consumoPorSegundo = 25;
    private const int bonusCombustible = 50;

    public Action<float> JugadorConsumeCombustible;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        combustibleMaximo = combustibleBase + (int)combustibleSobrante;
        combustible = combustibleMaximo;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (Instance != this) return;

        combustibleMaximo = combustibleBase + (int)combustibleSobrante;
        combustible = combustibleMaximo;

        JugadorConsumeCombustible?.Invoke(combustible);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        ProcesarInput();
    }

    public float getCombustible() => combustible;
    public float getCombustibleMaximo() => combustibleMaximo;

    private void ProcesarInput()
    {
        Propulsion();
        Rotacion();
    }

    private void Propulsion()
    {
        if (Keyboard.current.spaceKey.isPressed && combustible > 0)
        {
            rb.AddRelativeForce(Vector3.up);

            if (!audioSource.isPlaying)
                audioSource.Play();

            combustible -= consumoPorSegundo * Time.deltaTime;
            if (combustible < 0) combustible = 0;

            JugadorConsumeCombustible?.Invoke(combustible);
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void Rotacion()
    {
        if (Keyboard.current.dKey.isPressed)
        {
            var rot = transform.rotation;
            rot.z -= Time.deltaTime * 1;
            transform.rotation = rot;
        }
        else if (Keyboard.current.aKey.isPressed)
        {
            var rot = transform.rotation;
            rot.z += Time.deltaTime * 1;
            transform.rotation = rot;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colisión con: " + collision.gameObject.name);

        switch (collision.gameObject.tag)
        {
            case "ColisionSegura":
                print("Colisión segura");
                break;

            case "BonusCombustible":
                combustible += bonusCombustible;
                if (combustible > combustibleMaximo) combustible = combustibleMaximo;
                JugadorConsumeCombustible?.Invoke(combustible);
                Destroy(collision.gameObject);
                break;

            case "BasuraPoint":
                Destroy(collision.gameObject);
                print("Has destruido basura espacial...!!!");
                break;

            case "Finish":
                combustibleSobrante = combustible;
                print("Combustible sobrante para el próximo nivel: " + combustibleSobrante);

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;

            case "ColisionPeligrosa":
                print("Has chocado contra un asteroide");
                break;

            default:
                print($"Has chocado contra {collision.gameObject.name}. Game Over");
                break;
        }
    }
}
