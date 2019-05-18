using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public string levelSelectName = "LevelSelect";
    public string shopLevelName = "Shop";
    public SceneFader sceneFader;

    public void Play()
    {
        sceneFader.FadeTo(levelSelectName);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Shop()
    {
        sceneFader.FadeTo(shopLevelName);
    }

    private void Start()
    {
        TurretsStats.SetAllTurretStats();

    }
}
