using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingTextController : MonoBehaviour
{
    [SerializeField] int numberOfFramesToWait;
    Text text;
    int counter = 0;

    private void Awake()
    {
        text = GetComponentInParent<Text>();
    }

    private void Update()
    {
        if (counter >= numberOfFramesToWait)
        {
            if (text.text != "Loading...")
            {
                text.text += ".";
            }
            else
            {
                text.text = "Loading";
            }
            counter = 0;
        }
        counter++;
    }
}
