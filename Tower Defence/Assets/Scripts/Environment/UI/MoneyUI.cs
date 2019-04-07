using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Money UI text updater - UI_Top -> Money -> Script as Component
/// </summary>
public class MoneyUI : MonoBehaviour {

    public Text moneyText;

	void Update () {
        moneyText.text = "$" + PlayerStats.Money.ToString();
	}
}
