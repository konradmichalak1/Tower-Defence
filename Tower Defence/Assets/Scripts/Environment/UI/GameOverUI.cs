using UnityEngine;
using UnityEngine.SceneManagement;

//Game over class
public class GameOverUI : MonoBehaviour {

    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";

    private void Update()
    {
        if(gameObject.activeSelf)
        {
            Time.timeScale = 0f;
        }
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
