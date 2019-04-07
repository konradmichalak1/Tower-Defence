using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour {

    public Text roundsText;
    /// <summary>
    /// On enable, update roundText
    /// </summary>
    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();   
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("Go to menu");
    }


}
