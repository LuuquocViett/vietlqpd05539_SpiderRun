using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Player : MonoBehaviour
{
    public AudioClip[] Sound;
    public void SoundPlay(int SoundNumber) {
        GetComponent<AudioSource>().clip = Sound[SoundNumber];
        GetComponent<AudioSource>().Play();
    }
}
