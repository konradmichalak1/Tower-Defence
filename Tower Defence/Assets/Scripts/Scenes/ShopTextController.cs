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


    /// <summary> Value that turret Range Stat will be improved when upgraded.</summary>
    public static float RangeUpgradeTick = 0.25f;
    /// <summary> Value that turret FireRate Stat will be improved when upgraded.</summary>
    public static float FireRateUpgradeTick = 0.05f;
    public static int DamageOverTimeUpgradeTick = 1;
    public static float SlowPercentageUpgradeTick = 0.005f;
    public static int DamageUpgradeTick = 1;
    public static float SpeedUpgradeTick = 0.25f;
    public static float ExplosionRadiusUpgradeTick = 0.1f;

    //Value is actuall value of that stat
    const string RangeValueText = "RangeValueText";
    //Upgrade cost is actuall upgrade cost of that stat
    const string RangeUpgradeCostText = "RangeUpgradeCostText";
    //Progress is the value that will be achieved, when player upgrade it.
    const string RangeProgressValueText = "RangeProgressValueText";
    //Current Range upgrade level
    const string RangeLvlText = "RangeLvlText";

    //Value is actuall value of that stat
    const string FireRateValueText = "FireRateValueText";
    //Upgrade cost is actuall upgrade cost of that stat
    const string FireRateUpgradeCostText = "FireRateUpgradeCostText";
    //Progress is the value that will be achieved, when player upgrade it.
    const string FireRateProgressValueText = "FireRateProgressValueText";
    //Current FireRate upgrade level
    const string FireRateLvlText = "FireRateLvlText";


    //Value is actuall value of that stat
    const string DamageOverTimeValueText = "DamageOverTimeValueText";
    //Upgrade cost is actuall upgrade cost of that stat
    const string DamageOverTimeUpgradeCostText = "DamageOverTimeUpgradeCostText";
    //Progress is the value that will be achieved, when player upgrade it.
    const string DamageOverTimeProgressValueText = "DamageOverTimeProgressValueText";
    //Current upgrade level
    const string DamageOverTimeLvlText = "DamageOverTimeLvlText";


    //Value is actuall value of that stat
    const string SlowPercentageValueText = "SlowPercentageValueText";
    //Upgrade cost is actuall upgrade cost of that stat
    const string SlowPercentageUpgradeCostText = "SlowPercentageUpgradeCostText";
    //Progress is the value that will be achieved, when player upgrade it.
    const string SlowPercentageProgressValueText = "SlowPercentageProgressValueText";
    //Current  upgrade level
    const string SlowPercentageLvlText = "SlowPercentageLvlText";


    //Value is actuall value of that stat
    const string DamageValueText = "DamageValueText";
    //Upgrade cost is actuall upgrade cost of that stat
    const string DamageUpgradeCostText = "DamageUpgradeCostText";
    //Progress is the value that will be achieved, when player upgrade it.
    const string DamageProgressValueText = "DamageProgressValueText";
    //Current  upgrade level
    const string DamageLvlText = "DamageLvlText";


    //Value is actuall value of that stat
    const string SpeedValueText = "SpeedValueText";
    //Upgrade cost is actuall upgrade cost of that stat
    const string SpeedUpgradeCostText = "SpeedUpgradeCostText";
    //Progress is the value that will be achieved, when player upgrade it.
    const string SpeedProgressValueText = "SpeedProgressValueText";
    //Current  upgrade level
    const string SpeedLvlText = "SpeedLvlText";


    //Value is actuall value of that stat
    const string ExplosionRadiusValueText = "ExplosionRadiusValueText";
    //Upgrade cost is actuall upgrade cost of that stat
    const string ExplosionRadiusUpgradeCostText = "ExplosionRadiusUpgradeCostText";
    //Progress is the value that will be achieved, when player upgrade it.
    const string ExplosionRadiusProgressValueText = "ExplosionRadiusProgressValueText";
    //Current  upgrade level
    const string ExplosionRadiusLvlText = "ExplosionRadiusLvlText";

    private void Update()
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
                #region RANGE
                case RangeValueText:
                    {
                        float value = PlayerPrefs.GetFloat(fullItemName + "Range");

                        text.text = value.ToString();
                        break;
                    }

                case RangeUpgradeCostText:
                    {
                        int value = 10;
                        int level = PlayerPrefs.GetInt(fullItemName + "RangeLvl", 1);

                        text.text = "-" + value*level + "$";
                        break;
                    }

                case RangeProgressValueText:
                    {
                        float value = PlayerPrefs.GetFloat(fullItemName + "Range");
                        text.text = value + " -> " + "<b> " + (value + RangeUpgradeTick) + "</b>";
                        break;
                    }
                case RangeLvlText:
                    {
                        int level = PlayerPrefs.GetInt(fullItemName + "RangeLvl", 1);
                        text.text = "LVL " + level;
                        break;
                    }

                #endregion

                #region FIRERATE
                case FireRateValueText:
                    {
                        float value = PlayerPrefs.GetFloat(fullItemName + "FireRate");
                        text.text = value.ToString();
                        break;
                    }

                case FireRateUpgradeCostText:
                    {
                        int value = 10;
                        int level = PlayerPrefs.GetInt(fullItemName + "FireRateLvl", 1);
                        text.text = "-" + value * level + "$";
                        break;
                    }

                case FireRateProgressValueText:
                    {
                        float value = PlayerPrefs.GetFloat(fullItemName + "FireRate");
                        text.text = value + " -> " + "<b> " + (value + FireRateUpgradeTick) + "</b>";
                        break;
                    }

                case FireRateLvlText:
                    {
                        int level = PlayerPrefs.GetInt(fullItemName + "FireRateLvl", 1);
                        text.text = "LVL " + level;
                        break;
                    }
                #endregion


                #region DamageOverTime

                case DamageOverTimeValueText:
                    {
                        int value = PlayerPrefs.GetInt(fullItemName + "DamageOverTime");

                        text.text = value.ToString();
                        break;
                    }

                case DamageOverTimeUpgradeCostText:
                    {
                        int value = 20;
                        int level = PlayerPrefs.GetInt(fullItemName + "DamageOverTimeLvl", 1);

                        text.text = "-" + value * level + "$";
                        break;
                    }

                case DamageOverTimeProgressValueText:
                    {
                        int value = PlayerPrefs.GetInt(fullItemName + "DamageOverTime");
                        text.text = value + " -> " + "<b> " + (value + DamageOverTimeUpgradeTick) + "</b>";
                        break;
                    }
                case DamageOverTimeLvlText:
                    {
                        int level = PlayerPrefs.GetInt(fullItemName + "DamageOverTimeLvl", 1);
                        text.text = "LVL " + level;
                        break;
                    }

                #endregion

                #region SlowPercentage


                case SlowPercentageValueText:
                    {
                        float value = PlayerPrefs.GetFloat(fullItemName + "SlowPercentage");

                        text.text = value.ToString();
                        break;
                    }

                case SlowPercentageUpgradeCostText:
                    {
                        int value = 20;
                        int level = PlayerPrefs.GetInt(fullItemName + "SlowPercentageLvl", 1);

                        text.text = "-" + value * level + "$";
                        break;
                    }

                case SlowPercentageProgressValueText:
                    {
                        float value = PlayerPrefs.GetFloat(fullItemName + "SlowPercentage");
                        text.text = value + " -> " + "<b> " + (value + SlowPercentageUpgradeTick) + "</b>";
                        break;
                    }
                case SlowPercentageLvlText:
                    {
                        int level = PlayerPrefs.GetInt(fullItemName + "SlowPercentageLvl", 1);
                        text.text = "LVL " + level;
                        break;
                    }

                #endregion

                #region Damage
                case DamageValueText:
                    {
                        int value = PlayerPrefs.GetInt(fullItemName + "Damage");

                        text.text = value.ToString();
                        break;
                    }

                case DamageUpgradeCostText:
                    {
                        int value = 25;
                        int level = PlayerPrefs.GetInt(fullItemName + "DamageLvl", 1);

                        text.text = "-" + value * level + "$";
                        break;
                    }

                case DamageProgressValueText:
                    {
                        int value = PlayerPrefs.GetInt(fullItemName + "Damage");
                        text.text = value + " -> " + "<b> " + (value + DamageUpgradeTick) + "</b>";
                        break;
                    }
                case DamageLvlText:
                    {
                        int level = PlayerPrefs.GetInt(fullItemName + "DamageLvl", 1);
                        text.text = "LVL " + level;
                        break;
                    }

                #endregion


                #region Speed


                case SpeedValueText:
                    {
                        float value = PlayerPrefs.GetFloat(fullItemName + "Speed");

                        text.text = value.ToString();
                        break;
                    }

                case SpeedUpgradeCostText:
                    {
                        int value = 20;
                        int level = PlayerPrefs.GetInt(fullItemName + "SpeedLvl", 1);

                        text.text = "-" + value * level + "$";
                        break;
                    }

                case SpeedProgressValueText:
                    {
                        float value = PlayerPrefs.GetFloat(fullItemName + "Speed");
                        text.text = value + " -> " + "<b> " + (value + SpeedUpgradeTick) + "</b>";
                        break;
                    }
                case SpeedLvlText:
                    {
                        int level = PlayerPrefs.GetInt(fullItemName + "SpeedLvl", 1);
                        text.text = "LVL " + level;
                        break;
                    }

                #endregion


                #region ExplosionRadius


                case ExplosionRadiusValueText:
                    {
                        float value = PlayerPrefs.GetFloat(fullItemName + "ExplosionRadius");

                        text.text = value.ToString();
                        break;
                    }

                case ExplosionRadiusUpgradeCostText:
                    {
                        int value = 15;
                        int level = PlayerPrefs.GetInt(fullItemName + "ExplosionRadiusLvl", 1);

                        text.text = "-" + value * level + "$";
                        break;
                    }

                case ExplosionRadiusProgressValueText:
                    {
                        float value = PlayerPrefs.GetFloat(fullItemName + "ExplosionRadius");
                        text.text = value + " -> " + "<b> " + (value + ExplosionRadiusUpgradeTick) + "</b>";
                        break;
                    }
                case ExplosionRadiusLvlText:
                    {
                        int level = PlayerPrefs.GetInt(fullItemName + "ExplosionRadiusLvl", 1);
                        text.text = "LVL " + level;
                        break;
                    }

                    #endregion
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

    public static string GetUpgradeLevel()
    {
        return upgradeLevel;
    }
}
