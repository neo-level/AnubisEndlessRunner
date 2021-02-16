using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    [SerializeField] private AudioClip nightSound;
    [SerializeField] private AudioClip daySound;
    [SerializeField] private AudioSource audioSource;

    public void PlayNightSound()
    {
        audioSource.clip = nightSound;
        audioSource.Play();
    }

    public void PlayDaySound()
    {
        audioSource.clip = daySound;
        audioSource.Play();
    }
}