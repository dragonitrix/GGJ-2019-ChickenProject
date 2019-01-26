using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageBar : MonoBehaviour
{
    [SerializeField]
    private Stat stat;
    private Image fillBar;

    private void Awake()
    {
        fillBar = GetComponent<Image>();
    }

    private void OnValidate()
    {
        if (stat != null)
        {
            gameObject.name = stat.name + "Bar";
        }
    }


    private void Update()
    {
        fillBar.fillAmount = stat.currentValue / stat.maxValue;
    }

}
