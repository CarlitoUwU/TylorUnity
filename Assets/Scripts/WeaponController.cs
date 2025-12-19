using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Transform[] shootSpawns;
    public GameObject bulletPrefab;

    [Header("Fire Settings")]
    public float fireRate = 1.5f;

    [Header("Pattern Chances")]
    [Range(0f, 1f)] public float singleChance = 0.5f;
    [Range(0f, 1f)] public float doubleChance = 0.35f;
    [Range(0f, 1f)] public float tripleChance = 0.15f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            ShootPattern();
            timer = 0f;
        }
    }

    void ShootPattern()
    {
        float roll = Random.value;

        if (roll < singleChance)
            ShootSingle();
        else if (roll < singleChance + doubleChance)
            ShootDouble();
        else
            ShootTriple();
    }

    void ShootSingle()
    {
        int index = Random.Range(0, shootSpawns.Length);
        Instantiate(bulletPrefab, shootSpawns[index].position, shootSpawns[index].rotation);
    }

    void ShootDouble()
    {
        int first = Random.Range(0, shootSpawns.Length);
        int second;

        do
        {
            second = Random.Range(0, shootSpawns.Length);
        } while (second == first);

        Instantiate(bulletPrefab, shootSpawns[first].position, shootSpawns[first].rotation);
        Instantiate(bulletPrefab, shootSpawns[second].position, shootSpawns[second].rotation);
    }

    void ShootTriple()
    {
        foreach (Transform spawn in shootSpawns)
        {
            Instantiate(bulletPrefab, spawn.position, spawn.rotation);
        }
    }
}
