using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class ShopController : MonoBehaviour {

    /// <summary> Scene fader </summary>
    public SceneFader sceneFader;
    /// <summary> Main menu scene name </summary>
    public string mainMenuLevel = "MainMenu";

    /// <summary> Reference to player amount of money text </summary>
    public Text MoneyText;

    [Header("Item info")]
    /// <summary> Currently selected shop item </summary>
    public GameObject selectedItem;
    public GameObject[] shopItems;
    /// <summary> Currently selected upgrade level </summary>
    public int selectedUpgradeLevel;
    private GameObject prev_icon;


    /// <summary> When shop item is clicked, sets reference of selectedItem and make it active. </summary>
    /// <param name="item"></param>
    public void SelectItem(GameObject shopItem)
    {
        selectedUpgradeLevel = 1;
        ShopTextController.SetUpgradeLevel(selectedUpgradeLevel);

        foreach (var item in shopItems)
        {
             item.SetActive(false);
        }

        selectedItem = null;
        selectedItem = shopItem;
        StartCoroutine(UpdateUITexts());
        selectedItem.SetActive(true);

    }

    /// <summary> When item upgrade level is clicked, sets current upgrade level and changes values </summary>
    /// <param name="itemLevel">Clicked game object - item level</param>
    public void SelectItemUpgradeLevel(GameObject itemLevel)
    {
        //Current child index in hierarchy of 'UpgradeLevelButtons'
        selectedUpgradeLevel = itemLevel.transform.GetSiblingIndex() + 1;
        StartCoroutine(UpdateUITexts());
    }

    /// <summary>
    /// Sets proper icon for selected item and its upgrade level.
    /// </summary>
    /// <param name="icon"></param>
    public void SelectItemUpgradeLevelIcon(GameObject icon)
    {
        if (prev_icon != null)
        {
            prev_icon.SetActive(false);
        }

        prev_icon = icon;

        icon.SetActive(true);
    }

    /// <summary>
    /// 
    /// </summary>
    public void BuyUpgrade(string upgradeStatName)
    {
        string fullItemName = ShopTextController.itemName + ShopTextController.GetUpgradeLevel();

        int basicValue = 10;
        int level = PlayerPrefs.GetInt(fullItemName + upgradeStatName + "Lvl", 1);

        int cost = basicValue * level;
        int playerMoneys = PlayerPrefs.GetInt("Money", 0);

        if (playerMoneys < cost)
        {
            return;
        }

        switch(upgradeStatName)
        {
            case "Range":
                {

                    PlayerPrefs.SetFloat(fullItemName + upgradeStatName, PlayerPrefs.GetFloat(fullItemName + upgradeStatName) + ShopTextController.RangeUpgradeTick);
                    break;
                }
            case "FireRate":
                {

                    PlayerPrefs.SetFloat(fullItemName + upgradeStatName, PlayerPrefs.GetFloat(fullItemName + upgradeStatName) + ShopTextController.FireRateUpgradeTick);
                    break;
                }
            case "DamageOverTime":
                {

                    PlayerPrefs.SetInt(fullItemName + upgradeStatName, PlayerPrefs.GetInt(fullItemName + upgradeStatName) + ShopTextController.DamageOverTimeUpgradeTick);
                    break;
                }

            case "SlowPercentage":
                {

                    PlayerPrefs.SetFloat(fullItemName + upgradeStatName, PlayerPrefs.GetFloat(fullItemName + upgradeStatName) + ShopTextController.SlowPercentageUpgradeTick);
                    break;
                }
            case "Damage":
                {

                    PlayerPrefs.SetInt(fullItemName + upgradeStatName, PlayerPrefs.GetInt(fullItemName + upgradeStatName) + ShopTextController.DamageUpgradeTick);
                    break;
                }
            case "Speed":
                {

                    PlayerPrefs.SetFloat(fullItemName + upgradeStatName, PlayerPrefs.GetFloat(fullItemName + upgradeStatName) + ShopTextController.SpeedUpgradeTick);
                    break;
                }
            case "ExplosionRadius":
                {

                    PlayerPrefs.SetFloat(fullItemName + upgradeStatName, PlayerPrefs.GetFloat(fullItemName + upgradeStatName) + ShopTextController.ExplosionRadiusUpgradeTick);
                    break;
                }
        }

        PlayerPrefs.SetInt(fullItemName + upgradeStatName + "Lvl", level + 1);
        PlayerPrefs.SetInt("Money", playerMoneys - cost);

        UpdateMoneyText();
        //ShopTextController.UpdateTexts();
        StartCoroutine(UpdateUITexts());
    }

    /// <summary>
    /// Updates shown text
    /// </summary>
    public IEnumerator UpdateUITexts()
    {
        yield return new WaitForSeconds(Time.deltaTime);
        
        ShopTextController.itemName = selectedItem.name.Replace("Content", "");
        ShopTextController.SetUpgradeLevel(selectedUpgradeLevel);
        ShopTextController.UpdateTexts();
        
    }




    /// <summary> Returns to main menu. </summary>
    public void Back()
    {
        sceneFader.FadeTo(mainMenuLevel);
    }
    /// <summary> FOR TESTS ONLY: RESET USER SAVED PROGRESS </summary>
    public void ResetUserSave()
    {
        PlayerPrefs.DeleteAll();
        Back();
    }

    /// <summary> FOR TESTS ONLY: ADD MONEY </summary>
    public void AddMoney(int amount)
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) + amount);
        UpdateMoneyText();
    }

    /// <summary> Updates money text on the screen. </summary>
    private void UpdateMoneyText()
    {
        MoneyText.text = PlayerPrefs.GetInt("Money", 0).ToString() + "$";
    }

    private void Start()
    {
        //standardTurret.SetActive(true);
        selectedUpgradeLevel = 1;
        UpdateMoneyText();
    }



}
