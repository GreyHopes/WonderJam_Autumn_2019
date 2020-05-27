using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cawotte.Toolbox;
using R;
using System;
using UnityEngine.EventSystems;

public class UpgradeManager : Singleton<UpgradeManager>
{
    public Button healthButton;
    public Button speedButton;
    public Button damageButton;
    public Button rofButton;
    public Button rangeButton;
    public Button projSpeedButton;

    private ShipSelector shipSelector;
    private Character currentCharacter = null;

    private void Awake()
    {
        GameManager.Instance.UpgradeMenu = this.gameObject;
        shipSelector = GameManager.Instance.ShipSelector;
        currentCharacter = shipSelector.GetSelectedShip();

        shipSelector.OnShipSelected += OnShipSelected;
    }

    private void Start()
    {
        GameManager.Instance.SetUpgradeMenuOpen(false);
        refreshButtons();
    }

    private void OnEnable()
    {
        if (!EventSystem.current.alreadySelecting)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(healthButton.gameObject);
        }
    }

    private void OnDestroy()
    {
        shipSelector.OnShipSelected -= OnShipSelected;
    }

    private void OnShipSelected(AlliedShip ship)
    {
        setupWithCharacter(ship);
    }

    public void setupWithCharacter(Character character)
    {
        currentCharacter = character;
        refreshButtons();
    }

    public void refreshButtons()
    {
        healthButton.GetComponent<UpgradeButtonUI>().showValues(currentCharacter.MaxHealth, currentCharacter.MaxHealthUpgrade.nextCost);
        speedButton.GetComponent<UpgradeButtonUI>().showValues((int)currentCharacter.Speed, currentCharacter.SpeedUpgrade.nextCost);
        damageButton.GetComponent<UpgradeButtonUI>().showValues((int)currentCharacter.Damage, currentCharacter.DamageUpgrade.nextCost);
        rofButton.GetComponent<UpgradeButtonUI>().showValues((int)currentCharacter.RateOfFire, currentCharacter.RateOfFireUpgrade.nextCost);
        rangeButton.GetComponent<UpgradeButtonUI>().showValues((int)currentCharacter.Range, currentCharacter.RangeUpgrade.nextCost);
        projSpeedButton.GetComponent<UpgradeButtonUI>().showValues((int)currentCharacter.ProjectileSpeed, currentCharacter.ProjectileSpeedUpgrade.nextCost);
    }

    public void onClickButton(int type)
    {
        currentCharacter.UpgradeStats(type);

        int cost = currentCharacter.UpgradeCostOfStat(type);

        if (GameManager.Instance.CanAfford(cost))
        {
            switch (type)
            {
                case S.DAMAGE:
                    damageButton.GetComponent<UpgradeButtonUI>().showValues((int)currentCharacter.Damage, currentCharacter.DamageUpgrade.nextCost);
                    break;

                case S.SPEED:
                    speedButton.GetComponent<UpgradeButtonUI>().showValues((int)currentCharacter.Speed, currentCharacter.SpeedUpgrade.nextCost);
                    break;

                case S.HP:
                    healthButton.GetComponent<UpgradeButtonUI>().showValues(currentCharacter.MaxHealth, currentCharacter.MaxHealthUpgrade.nextCost);
                    break;

                case S.PROJECTILE_SPEED:
                    projSpeedButton.GetComponent<UpgradeButtonUI>().showValues((int)currentCharacter.ProjectileSpeed, currentCharacter.ProjectileSpeedUpgrade.nextCost);
                    break;

                case S.RANGE:
                    rangeButton.GetComponent<UpgradeButtonUI>().showValues((int)currentCharacter.Range, currentCharacter.RangeUpgrade.nextCost);
                    break;

                case S.ROF:
                    rofButton.GetComponent<UpgradeButtonUI>().showValues((int)currentCharacter.RateOfFire, currentCharacter.RateOfFireUpgrade.nextCost);
                    break;

                default:
                    Debug.Log("Silently ignored " + type);
                    break;
            }

            GameManager.Instance.Pay(cost);
        }
        else
        {
            Debug.Log("You can't afford that !");
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
