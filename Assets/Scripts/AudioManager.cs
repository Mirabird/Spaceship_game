using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public AudioSource [] soundEffects;
    public static AudioManager instance;
    public AudioSource bgm;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        bgm.Play();
    }
    public void PlaySfx(int soundToPlay)
    {
        soundEffects[soundToPlay].Play();
    }
    public void StopBgm()
    {
        if (bgm != null && bgm.isPlaying)
        {
            bgm.Stop();
        }
    }
}
