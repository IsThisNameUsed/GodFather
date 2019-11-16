using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource[] audioSources;

    public void soundLaserBoss()
    {
        audioSources[0].Play();
    }

    public void soundDeathPlayer()
    {
        audioSources[1].Play();
    }

    public void soundTir1()
    {
        audioSources[2].Play();
    }

    public void soundTir2()
    {
        audioSources[3].Play();
    }

    public void soundTir3()
    {
        audioSources[4].Play();
    }

    public void soundDeathEnemy()
    {
        audioSources[5].Play();
    }

    public void soundImpact()
    {
        audioSources[6].Play();
    }

    public void soundTirEnemy()
    {
        audioSources[7].Play();
    }
}
