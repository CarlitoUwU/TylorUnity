using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    public float limiteIzquierdo = -6f;
    public float limiteDerecho = 6f;

    void Update()
    {
        float movimientoX = 0f;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            movimientoX = -1;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            movimientoX = 1;

        float nuevaX = transform.position.x + movimientoX * speed * Time.deltaTime;

        // 🔒 Aquí NO rompe nada
        nuevaX = Mathf.Clamp(nuevaX, limiteIzquierdo, limiteDerecho);

        transform.position = new Vector3(
            nuevaX,
            transform.position.y,
            transform.position.z
        );
    }
}
