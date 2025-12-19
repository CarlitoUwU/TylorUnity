using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI2d : MonoBehaviour
{
    public Slider slider;
    public PlayerHealth2d playerHealth;

    void Start()
    {
        slider.value = 1f;
        playerHealth.OnHealthChanged += UpdateHealth;
    }

    void UpdateHealth(float currentHealth)
    {
        slider.value = playerHealth.GetHealthNormalized();
    }
}
