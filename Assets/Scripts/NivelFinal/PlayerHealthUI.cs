using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Slider slider;
    public PlayerHealth playerHealth;

    void Start()
    {
        slider.value = 1f;
    }

    void Update()
    {
        slider.value = playerHealth.currentHealth / playerHealth.maxHealth;
    }
}
