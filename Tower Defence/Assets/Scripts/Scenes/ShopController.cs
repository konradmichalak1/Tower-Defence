using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopController : MonoBehaviour {

    public SceneFader sceneFader;
    public string mainMenuLevel = "MainMenu";
    public Text MoneyText;

    /// <summary>
    /// Returns to main menu.
    /// </summary>
	public void Back()
    {
        sceneFader.FadeTo(mainMenuLevel);
    }
    /// <summary>
    /// FOR TESTS ONLY: RESET USER SAVED PROGRESS
    /// </summary>
    public void ResetUserSave()
    {
        PlayerPrefs.DeleteAll();
        UpdateMoneyText();
    }

    /// <summary>
    /// Updates money text on the screen.
    /// </summary>
    private void UpdateMoneyText()
    {
        MoneyText.text = PlayerPrefs.GetInt("Money", 0).ToString() + "$";
    }

    private void Start()
    {
        UpdateMoneyText();
    }



    private void Update()
    {
       
    }



}
