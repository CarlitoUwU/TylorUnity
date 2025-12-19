using UnityEngine;

public class BossAudio : MonoBehaviour
{
    AudioSource audioSource;

    [Header("Clips")]
    public AudioClip hitClip;
    public AudioClip deathClip;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayHit()
    {
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(hitClip);
    }

    public void PlayDeath()
    {
        audioSource.PlayOneShot(deathClip);
    }
}
