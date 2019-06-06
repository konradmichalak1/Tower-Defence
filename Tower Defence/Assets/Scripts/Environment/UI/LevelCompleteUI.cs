using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    /// <summary>
    /// Money reward for that level.
    /// </summary>
    public int levelMoneyReward;

    public void Menu()
    {
        MoveToScene(menuSceneName);
    }

    public void Continue()
    {
        MoveToScene(nextLevel);
    }

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().name == "InfinityLevel")
        {
            levelMoneyReward = WaveSpawnerInfinity.MoneyReward;
        }

        //Add money to player global amount
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) + levelMoneyReward);
    }

    private void MoveToScene(string sceneName)
    {


        //Set max level reached number
        if (PlayerPrefs.GetInt("levelReached", 2) > levelToUnlock)
        {
            sceneFader.FadeTo(sceneName);
            return;
        }

        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(sceneName);
    }

}
