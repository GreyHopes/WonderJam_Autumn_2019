using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonController : MonoBehaviour
{
    ActivityManager activityManager;
    private void Awake()
    {
        activityManager = GameObject.FindGameObjectWithTag(R.S.MainTag).GetComponent<ActivityManager>();
    }

    public void StartGame()
    {
        activityManager.StartActivity(R.S.GameActivity);
    }
}
