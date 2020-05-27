using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadingScreenController : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    private ActivityManager activityManager;

    private void Awake()
    {
        activityManager = GameObject.FindGameObjectWithTag(R.S.MainTag).GetComponent<ActivityManager>();
        loadingScreen.SetActive(false);
    }

    private void OnEnable()
    {
        activityManager.OnActivityLoadStarted += OnActivityLoadStart;
        activityManager.OnActivityLoadEnded += OnActivityLoadEnd;
    }

    private void OnDisable()
    {
        activityManager.OnActivityLoadStarted -= OnActivityLoadStart;
        activityManager.OnActivityLoadEnded -= OnActivityLoadEnd;
    }

    private void OnActivityLoadStart()
    {
        loadingScreen.SetActive(true);
    }

    private void OnActivityLoadEnd()
    {
        loadingScreen.SetActive(false);
    }
}
