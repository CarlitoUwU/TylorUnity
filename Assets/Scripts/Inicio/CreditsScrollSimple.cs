using UnityEngine;

public class CreditsScrollSimple : MonoBehaviour
{
    public float speed = 20f; // más lento
    private Vector3 startPos;
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.localPosition;
    }

    void OnEnable()
    {
        rectTransform.localPosition = startPos;
    }

    void Update()
    {
        rectTransform.localPosition += Vector3.up * speed * Time.deltaTime;

        // cuando sube demasiado, reinicia
        if (rectTransform.localPosition.y >= startPos.y + 800f)
        {
            rectTransform.localPosition = startPos;
        }
    }
}
