using UnityEngine;

public class CircleRotator : MonoBehaviour
{
    public float rotationSpeed = 20f;

    void Start()
    {
        // pequeño desfase, NO exagerado
        transform.Rotate(Vector3.forward * Random.Range(0f, 45f));
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime, Space.Self);
    }

    public void SetSpeed(float speed)
    {
        rotationSpeed = speed;
    }
}
