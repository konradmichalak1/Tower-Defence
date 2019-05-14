using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class RoundSurvivedUI : MonoBehaviour {

    public Text roundsText;
    public Text moneyText;

    /// <summary>
    /// On enable, update roundText
    /// </summary>
    private void OnEnable()
    {
        StartCoroutine(AnimateRoundsText());
        StartCoroutine(AnimateMoneyText());
    }

    IEnumerator AnimateRoundsText()
    {
        roundsText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(.7f);

        while(round < PlayerStats.Rounds)
        {
            round++;
            roundsText.text = round.ToString();

            yield return new WaitForSeconds(.05f);
        }
    }

    IEnumerator AnimateMoneyText()
    {
        moneyText.text = "0";
        int money = 0;

        yield return new WaitForSeconds(.7f);

        while (money < GetComponentInParent<LevelCompleteUI>().levelMoneyReward)
        {
            money++;
            moneyText.text = money.ToString();

            yield return new WaitForSeconds(.01f);
        }
    }
}
