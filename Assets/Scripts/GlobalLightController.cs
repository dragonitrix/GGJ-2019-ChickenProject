using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalLightController : MonoBehaviour
{
    [SerializeField]
    private Stat dayLight;

    [SerializeField]
    private Setting settings;

    [SerializeField]
    private Image blackCurtain;

    private Light light;



    void Awake()
    {
        light = GetComponent<Light>();
        GameManager.Instance.OnDayStarts += NewDay;
        GameManager.Instance.OnDayEnds += EndDay;
    }

    private void NewDay()
    {
        light.intensity = 1;
        dayLight.ResetValue();

        StartCoroutine(FadeIn());
        StartCoroutine(DayToNight());
    }


    private IEnumerator FadeIn()
    {
        float curtainAlpha = 1f;
        blackCurtain.color = new Color(0, 0, 0, curtainAlpha);

        while (curtainAlpha > 0)
        {
            curtainAlpha -= Time.deltaTime / 5f;
            blackCurtain.color = new Color(0, 0, 0, curtainAlpha);

            yield return null;
        }
    }


    IEnumerator DayToNight()
    {
        yield return new WaitForSeconds(settings.dayLengthInSec);
        float dayLightCounter = settings.dayLengthInSec;

        while (dayLightCounter > 0)
        {
            dayLightCounter -= Time.deltaTime;
            dayLight.currentValue -= Time.deltaTime / settings.dayLengthInSec;

            light.intensity = dayLight.currentValue / dayLight.maxValue;

            yield return null;
        }

      StartCoroutine(NightToDay());
    }

    

    IEnumerator NightToDay()
    {
        yield return new WaitForSeconds(settings.dayLengthInSec);
        float dayLightCounter = -settings.dayLengthInSec;

        while (dayLightCounter < 0)
        {
            dayLightCounter += Time.deltaTime;
            dayLight.currentValue += Time.deltaTime / settings.dayLengthInSec;

            light.intensity = dayLight.currentValue / dayLight.maxValue;
            
            yield return null;
        }

      StartCoroutine(DayToNight());
    }

    
    public void EndDay()
    {
        StopAllCoroutines();
        StartCoroutine(FadeToBlack());
    }
         


    private IEnumerator FadeToBlack()
    {
        float curtainAlpha = 0f;

        while (curtainAlpha < 1)
        {
            curtainAlpha += Time.deltaTime / 5f;

            blackCurtain.color = new Color (0,0,0, curtainAlpha);

            yield return null;
        }
    }

         

}
