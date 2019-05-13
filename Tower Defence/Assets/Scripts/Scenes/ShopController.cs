using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour {

    public SceneFader sceneFader;
    public string mainMenuLevel = "MainMenu";
	public void Back()
    {
        sceneFader.FadeTo(mainMenuLevel);
    }
}
