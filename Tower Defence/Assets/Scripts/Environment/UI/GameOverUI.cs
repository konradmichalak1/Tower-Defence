using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//Game over class
public class GameOverUI : MonoBehaviour {

    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";
    public Text wavesSurvivedCounter;

    private void Update()
    {
        if(gameObject.activeSelf)
        {
            Time.timeScale = 0f;
        }
    }

    private void OnEnable()
    {
        wavesSurvivedCounter.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        Time.timeScale = 1f;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        Time.timeScale = 1f;
        sceneFader.FadeTo(menuSceneName);
    }


}
