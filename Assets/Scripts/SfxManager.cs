using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SfxManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private List<AudioClip> gameSfXs;

    public void PlaySfx(string clipToPlay)
    {
        switch (clipToPlay)
        {
            case "Coin":
                audioSource.clip = gameSfXs[2];
                break;
            case "Jump":
                audioSource.clip = gameSfXs[5];
                break;
            case "DoubleJump":
                audioSource.clip = gameSfXs[3];
                break;
            case "PowerUpDoubleJump":
                audioSource.clip = gameSfXs[7];
                break;
            case "Land":
                audioSource.clip = gameSfXs[6];
                break;
            case "PowerUpShield":
                audioSource.clip = gameSfXs[8];
                break;
            case "ShieldBreak":
                audioSource.clip = gameSfXs[9];
                break;
            case "GameOverHit":
                audioSource.clip = gameSfXs[4];
                break;
            case "AmbienceBase":
                audioSource.clip = gameSfXs[0];
                break;
            case "AmbienceNight":
                audioSource.clip = gameSfXs[1];
                break;
        }

        audioSource.Play();
    }
}