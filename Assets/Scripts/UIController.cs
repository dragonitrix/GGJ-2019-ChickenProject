using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIController : MonoBehaviour
{

    public TextMeshProUGUI foodText;
    public TextMeshProUGUI branchText;

    [SerializeField]
    private Stat foodStat, branchStat, waterStat;
    


    void Update()
    {

        foodText.text = "Food: " + foodStat.currentValue;
        branchText.text = "Branch: " + branchStat.currentValue;


        var dayLength = 0f;
        switch (GameManager.Instance.dayState)
        {
            case GameManager.DayState.day:
                dayLength = GameManager.Instance.setting.dayLength;
                break;
            case GameManager.DayState.night:
                dayLength = GameManager.Instance.setting.nightLength;
                break;
            default:
                break;
        }


    }
}
