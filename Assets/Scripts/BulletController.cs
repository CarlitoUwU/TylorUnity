using UnityEngine;

public class Controladordebala : MonoBehaviour
{
    Rigidbody bulletRb;
    public float power = 100f;
    public float lifeTime = 4f;
    private float time = 0f;

    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.linearVelocity = transform.forward * power;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
