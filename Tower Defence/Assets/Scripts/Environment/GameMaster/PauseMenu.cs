using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour {

    public GameObject ui;
    public string manuSceneName = "MainMenu";
    public SceneFader sceneFader;

    private void Update()
    {
        //If game is over, player can't pause.
        if (GameManager.GameIsOver)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }
    /// <summary>
    /// Show/hide pause menu screen.
    /// </summary>
    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);
        if(ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo(manuSceneName);
    }
}
