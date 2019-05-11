using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour {

    public Text roundsText;
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";
    /// <summary>
    /// On enable, update roundText
    /// </summary>
    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();   
    }

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }


}
