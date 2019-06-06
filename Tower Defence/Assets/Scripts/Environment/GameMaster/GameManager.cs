﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class resposible for game ending. 
/// </summary>
public class GameManager : MonoBehaviour {

    public static bool GameIsOver;

    public GameObject gameOverUI;

    public GameObject completeLevelUI;

    private void Start()
    {
        GameIsOver = false;
    }

    void Update () {
        if (GameIsOver) return;


        if (PlayerStats.Lives <= 0)
        {
            if(SceneManager.GetActiveScene().name == "InfinityLevel")
            {
                WinLevel();
                return;
            }
            EndGame();
        }
	}

    private void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}
