using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Lives UI text updater - UI_Top -> Lives -> Script as Component
/// </summary>
public class LivesUI : MonoBehaviour {

    public Text livesText;

	void Update () {
        livesText.text = PlayerStats.Lives + " LIVES";
	}
}
