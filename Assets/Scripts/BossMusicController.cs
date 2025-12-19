using UnityEngine;

public class BossMusicController : MonoBehaviour
{
    AudioSource musicSource;

    void Awake()
    {
        musicSource = GetComponent<AudioSource>();
    }

    public void PlayBossMusic()
    {
        if (!musicSource.isPlaying)
            musicSource.Play();
    }

    public void StopBossMusic()
    {
        musicSource.Stop();
    }
}
