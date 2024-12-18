using System;
using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public AudioSource [] soundEffects;
    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlaySfx(int soundToPlay)
    {
        soundEffects[soundToPlay].Play();
    }
}
