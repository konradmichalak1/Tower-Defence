using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopController : MonoBehaviour {

    public SceneFader sceneFader;
    public string mainMenuLevel = "MainMenu";
    public Text MoneyText;
	public void Back()
    {
        sceneFader.FadeTo(mainMenuLevel);
    }

    private void Update()
    {
        MoneyText.text = PlayerPrefs.GetInt("Money", 0).ToString() + "$";
    }
}
