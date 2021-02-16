using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject gameMusic;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject sky;
    
    [SerializeField] private Player player;
    
    [SerializeField] private Text collectedCoins;
    [SerializeField] private Text distanceTravelledText;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameOver();
        }
    }

    public void GameRestart()
    {
        SceneManager.LoadScene("EndlessRunner");
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        gameMusic.SetActive(false);
        sky.SetActive(false);
        distanceTravelledText.text = $"Distance Travelled: {(int) player.distanceTravelled} m";
        collectedCoins.text = $"Collected Coins: {player.collectable}";
        Time.timeScale = 0.0f;
    }
}