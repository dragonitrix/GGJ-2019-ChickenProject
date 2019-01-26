using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public static GameManager instance;
    public Setting setting;
    [HideInInspector]
    public float lightValue = 1;
    float lightLerpSpeed = 5;
    [HideInInspector]
    public float currentDayTimer = 0;

    public Stat food;
    public Stat branch;
    public Stat water;

    public enum DayState
    {
        day,night
    }
    public DayState dayState;
    public void setDayState(DayState targetState)
    {
        dayState = targetState;
        switch (dayState)
        {
            case DayState.day:
                currentDayTimer = setting.dayLength;
                StartCoroutine(NightToDay());
                break;
            case DayState.night:
                currentDayTimer = setting.nightLength;
                StartCoroutine(DayToNight());
                break;
            default:
                break;
        }
    }
    IEnumerator DayToNight()
    {
        while (lightValue > 0.01)
        {
            lightValue = Mathf.Lerp(lightValue, 0, lightLerpSpeed * Time.deltaTime);
            yield return null;
        }
        lightValue = 0;
    }
    IEnumerator NightToDay()
    {
        while (lightValue < 0.99)
        {
            lightValue = Mathf.Lerp(lightValue, 1, lightLerpSpeed * Time.deltaTime);
            yield return null;
        }
        lightValue = 1;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dayState = DayState.day;
        lightValue = 1;
        currentDayTimer = setting.dayLength;

        food.currentValue = food.initialValue;
        water.currentValue = water.initialValue;
        branch.currentValue = branch.initialValue;

    }

    // Update is called once per frame
    void Update()
    {
        currentDayTimer -= Time.deltaTime;
        if (currentDayTimer <=0)
        {
            switch (dayState)
            {
                case DayState.day:
                    setDayState(DayState.night);
                    break;
                case DayState.night:
                    setDayState(DayState.day);
                    break;
                default:
                    break;
            }
        }


        if (Input.GetKeyDown(KeyCode.P))
        {
            switch (GameManager.instance.dayState)
            {
                case GameManager.DayState.day:
                    GameManager.instance.setDayState(GameManager.DayState.night);
                    break;
                case GameManager.DayState.night:
                    GameManager.instance.setDayState(GameManager.DayState.day);
                    break;
                default:
                    break;
            }
        }

    }

    public void PickupObject(PickableObject.Type type)
    {
        switch (type)
        {
            case PickableObject.Type.food:
                food.currentValue++;
                break;
            case PickableObject.Type.water:
                water.currentValue++;
                break;
            case PickableObject.Type.branch:
                branch.currentValue++;
                break;
            default:
                break;
        }
    }

}
