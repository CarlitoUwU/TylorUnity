using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Transform shootSpawn;
    public bool shooting;
    public GameObject bulletPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        shooting = Input.GetKeyDown(KeyCode.Mouse0);
        if (shooting)
        {
            InstantiateNullet();
        }
    }
    public void InstantiateNullet() {
        Instantiate(bulletPrefab, shootSpawn.position, shootSpawn.rotation);
    }
}
