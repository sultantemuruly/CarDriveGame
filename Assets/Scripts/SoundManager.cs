using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource soundSource;
    private static AudioSource SoundSource;
    [SerializeField] private AudioClip coinSound;
    private static AudioClip CoinSound;
    [SerializeField] private AudioClip finishSound;
    private static AudioClip FinishSound;

    public static void OnCoinSound()
    {
        //SoundSource.PlayOneShot(CoinSound);
    }

    public static void OnFinishSound()
    {
        //SoundSource.PlayOneShot(FinishSound);
    }
}
