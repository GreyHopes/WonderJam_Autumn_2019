using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct PortraitMapping
{
    public string name;
    public AllyPortrait character;
}
public class HUD : MonoBehaviour
{

    [SerializeField]
    private Text textCredits;
    
    [SerializeField]
    private Text textTimer;
    
    [SerializeField]
    private Text textRound;

    [SerializeField]
    private GameObject upgradePanel;

    [SerializeField]
    private Text upgradeTimer;
    
    [SerializeField]
    public PortraitMapping[] allyPortraitsArray;

    private bool shouldFlash;

    private Dictionary<string,AllyPortrait> allyPortraits;

    private void Start()
    {
        GameManager.Instance.Hud = this;
        GameManager.Instance.InitializeHUD();

        upgradePanel.SetActive(false);
        upgradeTimer.enabled = false;

        allyPortraits = new Dictionary<string, AllyPortrait>();

        foreach (PortraitMapping mapping in allyPortraitsArray)
        {
            allyPortraits.Add(mapping.name, mapping.character);
        }

        foreach(KeyValuePair<string,AlliedShip> character in GameManager.Instance.characters)
        {
            character.Value.OnHealthChange += (old, newValue) =>
            {
                allyPortraits[character.Key].SetTextHPCurrent(newValue);
                allyPortraits[character.Key].ScaleLifebar(newValue, character.Value.MaxHealth);
            }; 
            allyPortraits[character.Key].SetTextHPCurrent(character.Value.CurrentHealth);

            character.Value.OnMaxHealthChange += (newValue) =>
            {
                allyPortraits[character.Key].SetTextHPMax(newValue);
            };
            allyPortraits[character.Key].SetTextHPMax(character.Value.MaxHealth);
        }
    }

    public void StartFlashUpgrade()
    {
        upgradePanel.SetActive(true);
        shouldFlash = true;
        StartCoroutine(FlashUpgrade());
    }

    public void UpdateUpgradeTimer(float value)
    {
        int time = (int)value;
        upgradeTimer.text = time.ToString();
    }

    public void StopFlashUpgrade()
    {
        shouldFlash = false;
        upgradePanel.SetActive(false);
    }

    public void SetTextRound(int numRound)
    {
        textRound.text = numRound.ToString();
    }
    
    public void SetTextTimer(float time)
    {
        textTimer.text = ((int) Mathf.Floor(time)).ToString();
    }

    public void SetCreditsUI(int numCredit)
    {
        textCredits.text = numCredit.ToString();
    }

    private IEnumerator FlashUpgrade()
    {
        while (shouldFlash)
        {
            upgradeTimer.enabled = true;
            yield return new WaitForSeconds(0.75f);
            upgradeTimer.enabled = false;
            yield return new WaitForSeconds(0.25f);
        }
    }
}
