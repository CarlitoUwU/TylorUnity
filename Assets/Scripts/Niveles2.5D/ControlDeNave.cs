using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDeNave : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    Transform tf;

    [Header("Movimiento")]
    public float moveSpeed = 8f;
    public float smoothTime = 0.15f;

    [Header("Límites")]
    public Vector2 minBounds = new Vector2(-8f, -4f);
    public Vector2 maxBounds = new Vector2(8f, 4f);

    [Header("Vida")]
    public PlayerHealth2d playerHealth2d;

    CombustibleData combustibleData;
    Vector3 currentVelocity;

    public Action<float> JugadorConsumeCombustible;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        tf = transform;

        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        tf.rotation = Quaternion.identity;

        combustibleData = CombustibleData.Instance;
        combustibleData.addCombustible(100f);
    }

    private void Update()
    {
        MovimientoSuave();
    }

    private void MovimientoSuave()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 inputDir = new Vector3(h, v, 0f).normalized;

        Vector3 targetVelocity = inputDir * moveSpeed;

        Vector3 velocity = Vector3.SmoothDamp(
            rb.linearVelocity,
            targetVelocity,
            ref currentVelocity,
            smoothTime
        );

        rb.linearVelocity = new Vector3(velocity.x, velocity.y, 0f);

        if (inputDir.magnitude > 0.1f && combustibleData.hasCombustible())
        {
            combustibleData.consumeCombustible();
            JugadorConsumeCombustible?.Invoke(combustibleData.getCombustible());

            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void LateUpdate()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minBounds.x, maxBounds.x);
        pos.y = Mathf.Clamp(pos.y, minBounds.y, maxBounds.y);
        pos.z = 0f;

        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger con: " + other.gameObject.name);

        switch (other.tag)
        {
            case "ColisionPeligrosa":
                RecibirDañoPorMeteorito(15f);
                Destroy(other.gameObject);
                break;

            case "BonusCombustible":
                combustibleData.bonusCombustibleAmount();
                JugadorConsumeCombustible?.Invoke(combustibleData.getCombustible());
                Destroy(other.gameObject);
                break;

            case "BasuraPoint":
                Destroy(other.gameObject);
                Debug.Log("Basura recolectada");
                break;

            case "Finish":
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
        }
    }


    // 🔹 MÉTODOS NECESARIOS PARA LA BARRA DE COMBUSTIBLE 🔹
    public float getCombustible()
    {
        return combustibleData.getCombustible();
    }

    public float getCombustibleMaximo()
    {
        return combustibleData.getCombustibleMaximo();
    }

    // 🔹 DAÑO 🔹
    public void RecibirDañoPorMeteorito(float cantidad)
    {
        if (playerHealth2d != null)
            playerHealth2d.TakeDamage(cantidad);
    }
}
