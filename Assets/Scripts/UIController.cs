using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIController : MonoBehaviour
{

    public TextMeshProUGUI foodText;
    public TextMeshProUGUI branchText;
    public TextMeshProUGUI waterText;

    [SerializeField]
    private Stat foodStat, branchStat, waterStat;


    public Image dayBar;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        foodText.text = "Food: " + GameManager.instance.food.currentValue;
        branchText.text = "Branch: " + GameManager.instance.branch.currentValue;
        waterText.text = "Water: " + GameManager.instance.water.currentValue;


        var dayLength = 0f;
        switch (GameManager.instance.dayState)
        {
            case GameManager.DayState.day:
                dayLength = GameManager.instance.setting.dayLength;
                break;
            case GameManager.DayState.night:
                dayLength = GameManager.instance.setting.nightLength;
                break;
            default:
                break;
        }
        dayBar.rectTransform.localScale = new Vector2((GameManager.instance.currentDayTimer / dayLength),1);

    }
}
