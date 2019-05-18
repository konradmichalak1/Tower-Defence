using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class that contains all shop items text references. 
/// </summary>
[System.Serializable]
public class ShopTextController : MonoBehaviour
{
    /// <summary> All text that are related with selected item </summary>
    public Text[] texts;
    static public Text[] Texts;

    public static string itemName;
    private static string upgradeLevel;


    //Value is actuall value of that stat
    const string RangeValueText = "RangeValueText";
    //Upgrade cost is actuall upgrade cost of that stat
    const string RangeUpgradeCostText = "RangeUpgradeCostText";
    //Progress is the value that will be achieved, when player upgrade it.
    const string RangeProgressValueText = "RangeProgressValueText";

    //Value is actuall value of that stat
    const string FireRateValueText = "FireRateValueText";
    //Upgrade cost is actuall upgrade cost of that stat
    const string FireRateUpgradeCostText = "FireRateUpgradeCostText";
    //Progress is the value that will be achieved, when player upgrade it.
    const string FireRateProgressValueText = "FireRateProgressValueText";


    private void Start()
    {
        Texts = texts;
    }

    public static void UpdateTexts()
    {
        string fullItemName = itemName + upgradeLevel;
        foreach (var text in Texts)
        {
            switch (text.name)
            {
                case RangeValueText:
                    {
                        float value = PlayerPrefs.GetFloat(fullItemName + "Range");

                        text.text = value.ToString();
                        break;
                    }

                case RangeUpgradeCostText:
                    {
                        int value = 50;
                        text.text = "-" + value + "$";
                        break;
                    }

                case RangeProgressValueText:
                    {
                        float value = PlayerPrefs.GetFloat(fullItemName + "Range");
                        text.text = value + " -> " + "<b> " + (value+0.25f) + "</b>";
                        break;
                    }

                case FireRateValueText:
                    {
                        float value = PlayerPrefs.GetFloat(fullItemName + "FireRate");
                        text.text = value.ToString();
                        break;
                    }

                case FireRateUpgradeCostText:
                    {
                        int value = 60;
                        text.text = "-" + value + "$";
                        break;
                    }

                case FireRateProgressValueText:
                    {
                        float value = PlayerPrefs.GetFloat(fullItemName + "FireRate");
                        text.text = value + " -> " + "<b> " + (value + 0.05f) + "</b>";
                        break;
                    }
            }
        }
    }

    private void CalculateUpgradeCost(float value)
    {
    }

    /// <summary> Set selected upgrade level </summary>
    /// <param name="level"></param>
    public static void SetUpgradeLevel(int level)
    {
        if (level == 1)
        {
            upgradeLevel = string.Empty;
        }

        if (level == 2)
        {
            upgradeLevel = "Upgraded";
        }
    }
}
