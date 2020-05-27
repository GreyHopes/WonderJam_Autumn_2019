using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class AllyPortrait
{
    [SerializeField]
    private Text textHPMax; 
    
    [SerializeField]
    private Text textHPCurrent;

    [SerializeField]
    private Image lifebar;

    [SerializeField]
    private int lifebarScale;

    public void SetTextHPMax(int hpMax)
    {
        textHPMax.text = hpMax.ToString();
    }
    
    public void SetTextHPCurrent(int hpCurrent)
    {
        hpCurrent = Mathf.Max(0, hpCurrent);
        textHPCurrent.text = hpCurrent.ToString();
    }

    public void ScaleLifebar(int current, int max)
    {
        if (current > 0)
        {
            float newScale = ((float)current / (float)max) * (float)lifebarScale;
            lifebar.rectTransform.sizeDelta = new Vector2(newScale, lifebar.rectTransform.sizeDelta.y);
        }
        else
        {
            lifebar.rectTransform.sizeDelta = new Vector2(0, lifebar.rectTransform.sizeDelta.y);
        }

    }
}
