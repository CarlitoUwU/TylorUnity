using UnityEngine;

public class CombustibleData : MonoBehaviour
{
    public static CombustibleData Instance;

    [SerializeField] private float combustible = 0f;
    [SerializeField] private float combustibleMaximo = 100f;
    [SerializeField] private int consumoPorSegundo = 5;
    [SerializeField] private int bonusCombustible = 50;

    void Awake()
    {
        if (CombustibleData.Instance == null)
        {
            CombustibleData.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public bool hasCombustible()
    {
        return combustible > 0;
    }

    public float getCombustible()
    {
        return combustible;
    }

    public float getCombustibleMaximo()
    {
        return combustibleMaximo;
    }

    public void addCombustible(float amount)
    {
        combustible += amount;
        if (combustible > combustibleMaximo)
        {
            combustibleMaximo = combustible;
        }
    }

    public void consumeCombustible()
    {
        combustible -= consumoPorSegundo * Time.deltaTime;
        if (combustible < 0)
        {
            combustible = 0;
        }
    }

    public void bonusCombustibleAmount()
    {
        combustible += bonusCombustible;
        if (combustible > combustibleMaximo)
        {
            combustibleMaximo = combustible;
        }
    }
}
