using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;

public delegate void ActivityLoadStarted();
public delegate void ActivityLoadEnded();
public class ActivityManager : MonoBehaviour
{
    public event ActivityLoadStarted OnActivityLoadStarted;
    public event ActivityLoadEnded OnActivityLoadEnded;

    [SerializeField] Activity[] activities;
    [SerializeField] Activity startingActivity;

    Activity currentActivity;
    string activityToStart;

    private void Awake()
    {
        currentActivity = startingActivity;
        foreach (var i in startingActivity.Scenes)
        {
            bool mustLoad = true;
            for (int j = 0; j < SceneManager.sceneCount; j++)
            {
                if (SceneManager.GetSceneAt(j).name == i)
                {
                    mustLoad = false;
                    break;
                }
            }
            if (mustLoad)
            {
                SceneManager.LoadScene(i, LoadSceneMode.Additive);
            }
        }
        SceneManager.LoadScene(R.S.LoadingScreenScene, LoadSceneMode.Additive);
    }

    public void StartActivity(string activityName)
    {
        activityToStart = activityName;
        Time.timeScale = 0;
        OnActivityLoadStarted();
        List<Activity> activities = new List<Activity>(this.activities);
        Activity activityToRun;

        foreach (var i in currentActivity.Scenes)
        {
            SceneManager.UnloadSceneAsync(i);
        }

        if (!SceneManager.GetSceneByName(R.S.MainScene).isLoaded)
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Additive);
        }
        
        activityToRun = activities.First(x => x.name == activityToStart);
        foreach (var i in activityToRun.Scenes)
        {
            SceneManager.LoadScene(i, LoadSceneMode.Additive);
        }

        if (!SceneManager.GetSceneByName(R.S.LoadingScreenScene).isLoaded)
        {
            SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Additive);
        }

        currentActivity = activityToRun;

        StartCoroutine(StartActivityCoroutine());    
    }

    private IEnumerator StartActivityCoroutine()
    {
        yield return new WaitForSecondsRealtime(3);
        OnActivityLoadEnded();
        Time.timeScale = 1;
    }
}
