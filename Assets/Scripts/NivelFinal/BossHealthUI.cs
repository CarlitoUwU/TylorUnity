using UnityEngine;
using UnityEngine.UI;

public class BossHealthUI : MonoBehaviour
{
    public Slider slider;
    public BossController boss;

    void Start()
    {
        slider.value = 1f;
    }

    void Update()
    {
        slider.value = boss.currentHealth / boss.maxHealth;
    }
}
