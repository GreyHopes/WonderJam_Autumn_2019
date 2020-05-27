using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject buttonToSelect;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Image[] imageToFade;
    [SerializeField] private Text[] textToFade;
    private GameManager gameManager;
    private ActivityManager activityManager;

    private void Awake()
    {
        activityManager = GameObject.FindGameObjectWithTag(R.S.MainTag).GetComponent<ActivityManager>();
        gameManager = GameObject.FindGameObjectWithTag(R.S.GameManagerTag).GetComponent<GameManager>();
        gameManager.OnGameEnd += EnableGameOver;
        gameOverScreen.SetActive(false);
    }

    private void OnDestroy()
    {
        gameManager.OnGameEnd -= EnableGameOver;
    }

    private void EnableGameOver()
    {
        gameOverScreen.SetActive(true);
        StartCoroutine(FadeIn());
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        activityManager.StartActivity(R.S.GameActivity);
    }

    public void ReturnToMainMenu()
    {
        StopAllCoroutines();
        Time.timeScale = 1;
        activityManager.StartActivity(R.S.MainMenuActivity);
    }

    private IEnumerator FadeIn()
    {
        EventSystem.current.SetSelectedGameObject(null);
        float currentAlpha = 0f;
        while (currentAlpha < 1f)
        {
            for (int i = 0; i < imageToFade.Length; i++)
            {
                Color color = imageToFade[i].color;
                color.a = currentAlpha;
                imageToFade[i].color = color;
            }
            for (int i = 0; i < textToFade.Length; i++)
            {
                Color color = textToFade[i].color;
                color.a = currentAlpha;
                textToFade[i].color = color;
            }
            currentAlpha += 0.01f;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        Time.timeScale = 0;
        EventSystem.current.SetSelectedGameObject(buttonToSelect);
        yield return null;
    }
}
