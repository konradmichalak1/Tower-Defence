using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if(Input.GetKeyDown("e"))
        {
            EndGame();
        }
        if (Input.GetKeyDown("r"))
        {
            WinLevel();
        }
        if (PlayerStats.Lives <= 0)
        {
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
