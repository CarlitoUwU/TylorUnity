using UnityEngine;

public class CameraIdleMotion : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float amplitude = 0.1f;
    public float frequency = 1f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float x = Mathf.Sin(Time.time * frequency) * amplitude;
        float y = Mathf.Cos(Time.time * frequency) * amplitude;

        transform.localPosition = startPos + new Vector3(x, y, 0);
    }

}
