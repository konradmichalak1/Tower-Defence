using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    /// <summary> Currently selected upgrade level </summary>
    public int selectedUpgradeLevel;




    /// <summary> When shop item is clicked, sets reference of selectedItem and make it active. </summary>
    /// <param name="item"></param>
    public void SelectItem(GameObject shopItem)
    {
        shopItem.SetActive(true);
        selectedItem = shopItem;
        StartCoroutine(UpdateUITexts());
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
