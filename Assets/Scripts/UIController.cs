using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIController : MonoBehaviour
{

    public TextMeshProUGUI foodText;
    public TextMeshProUGUI branchText;
    public TextMeshProUGUI scoreText;



    [SerializeField]
    private Stat foodStat, branchStat, waterStat;
    

    void Update()
    {
        foodText.text = "Food: " + foodStat.currentValue;
        branchText.text = "Branch: " + branchStat.currentValue;

        scoreText.text = "Score: " + GameManager.Instance.score.ToString("F0");

        
 


    }
}
