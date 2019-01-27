using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckGameOver : MonoBehaviour
{
    [SerializeField]
    private Stat playerHealth, homeHealth;
    [SerializeField]
    private CanvasGroup gameOverCanvas;

    private bool gameOver;


    public Action OnGameOver = delegate { };

    private void Update()
    {

        if (playerHealth.currentValue <= 0 || homeHealth.currentValue <= 0)
        {
            if (!gameOver)
            {
                gameOver = true;
               StartCoroutine(GameOverRoutine());
            }
        }
        else
            gameOver = false;
    }

 

    public void GameOver()
    {
        StartCoroutine(GameOverRoutine());
    }


    private IEnumerator GameOverRoutine()
    {
        OnGameOver();
        gameOverCanvas.gameObject.SetActive(true);
        while(gameOverCanvas.alpha <1f)
        {
            gameOverCanvas.alpha += Time.deltaTime / 2f;
            yield return null;
        }

    }


 

    public void  ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

}
