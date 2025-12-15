using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        float movimientoX = 0;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            movimientoX = -1;  // Mueve hacia la izquierda
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            movimientoX = 1;   // Mueve hacia la derecha

        transform.position = new Vector3(
            transform.position.x + movimientoX * speed * Time.deltaTime,
            transform.position.y,
            transform.position.z
        );
    }
}
