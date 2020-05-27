using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipSelector : MonoBehaviour
{
    [Tooltip("The ships must be in the desired order.")]
    [SerializeField] AlliedShip[] alliedShips;

    public Action<AlliedShip> OnShipSelected;

    private int selectedShipIndex = 0;
    private Controls playerControls;

    private void Awake()
    {
        playerControls = new Controls();
    }

    private void Start()
    {
        NotifyShipSelection();
    }

    private void OnEnable()
    {
        playerControls.GameControls.Enable();

        playerControls.GameControls.NextShip.performed += OnNextShip;
        playerControls.GameControls.PreviousShip.performed += OnPreviousShip;

        for (int i = 0; i < alliedShips.Length; i++)
        {
            alliedShips[i].OnAllyDeath += OnAllyDeath;
        }
    }

    private void OnDisable()
    {
        playerControls.GameControls.NextShip.performed -= OnNextShip;
        playerControls.GameControls.PreviousShip.performed -= OnPreviousShip;

        playerControls.GameControls.Enable();


        for (int i = 0; i < alliedShips.Length; i++)
        {
            alliedShips[i].OnAllyDeath -= OnAllyDeath;
        }
    }

    private void OnAllyDeath(int deadAllyShipID)
    {
        if (deadAllyShipID == alliedShips[selectedShipIndex].GetInstanceID())
        {
            SelectNextShip();
        }
    }

    public AlliedShip GetSelectedShip()
    {
        return alliedShips[selectedShipIndex];
    }

    private void OnNextShip(InputAction.CallbackContext ctx)
    {
        SelectNextShip();
        if (OnShipSelected != null)
            OnShipSelected(alliedShips[selectedShipIndex]);
    }

    private void OnPreviousShip(InputAction.CallbackContext ctx)
    {
        SelectPreviousShip();
        if (OnShipSelected != null)
            OnShipSelected(alliedShips[selectedShipIndex]);
    }

    private void SelectNextShip()
    {
        //prevent infinite loop
        int loopCount = 0;
        do
        {
            selectedShipIndex = ((selectedShipIndex + 1) >= alliedShips.Length) ? 0 : (selectedShipIndex + 1);
            loopCount++;
        } while (alliedShips[selectedShipIndex].CurrentHealth <= 0 && loopCount < alliedShips.Length);

        NotifyShipSelection();
    }

    public void SelectPreviousShip()
    {
        //prevent infinite loop
        int loopCount = 0;
        do
        {
            selectedShipIndex = ((selectedShipIndex - 1) < 0) ? (alliedShips.Length - 1) : (selectedShipIndex - 1);
            loopCount++;
        } while (alliedShips[selectedShipIndex].CurrentHealth <= 0 && loopCount < alliedShips.Length);

        NotifyShipSelection();
    }

    private void NotifyShipSelection()
    {
        for (int i = 0; i < alliedShips.Length; i++)
        {
            alliedShips[i].OnSelectShip(alliedShips[selectedShipIndex].GetInstanceID());
        }
    }
}
