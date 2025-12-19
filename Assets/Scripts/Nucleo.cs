using UnityEngine;

public class Nucleo : MonoBehaviour
{
    public float amplitude = 0.05f;
    public float frequency = 2f;
    public Light coreLight;

    private Vector3 originalScale;
    private float baseLightIntensity;

    void Start()
    {
        originalScale = transform.localScale;

        if (coreLight != null)
            baseLightIntensity = coreLight.intensity;
    }

    void Update()
    {
        float pulse = 1 + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.localScale = originalScale * pulse;

        if (coreLight != null)
        {
            coreLight.intensity =
                baseLightIntensity + Mathf.Sin(Time.time * frequency) * baseLightIntensity * 0.5f;
        }
    }
}