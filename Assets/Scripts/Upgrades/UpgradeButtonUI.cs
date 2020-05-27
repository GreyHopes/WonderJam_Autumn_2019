using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using R;

public class UpgradeButtonUI : MonoBehaviour
{
    public TextMeshProUGUI currentValueTextBox;
    public TextMeshProUGUI nextValueCostTextBox;

    public void showValues(int currentValue,int cost)
    {
        currentValueTextBox.text = string.Format(S.ButtonCurrentValueFormat, currentValue);
        nextValueCostTextBox.text = string.Format(S.ButtonNextValueFormat, cost);
    }
}
