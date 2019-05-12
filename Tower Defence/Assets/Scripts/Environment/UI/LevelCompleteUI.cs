using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteUI : MonoBehaviour {

    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";

    /// <summary>
    /// Level to unlock name - type it in Unity Editor.
    /// </summary>
    public string nextLevel;
    /// <summary>
    /// Next level number. If there is only first level unlocked, this should be 2.
    /// </summary>
    public int levelToUnlock;

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }


}
