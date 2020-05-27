using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VirtualCursor : MonoBehaviour
{
    [Tooltip("Unity units per second.")]
    [SerializeField] private float movementSpeed;

    public Action<Vector2> OnClick;

    private Controls playerControls;
    private Vector2 movement;

    private Vector2 lastMousePos;
    private Vector2 currentMousePos;
    private bool enableMouseTracking = false;
    private void Awake()
    {
        playerControls = new Controls();
    }

    private void OnEnable()
    {
        playerControls.GameControls.Enable();

        playerControls.GameControls.MoveCursor.performed += ctx => OnMovementInput(ctx.ReadValue<Vector2>());
        playerControls.GameControls.MoveCursor.performed += ctx => enableMouseTracking = false;
        playerControls.GameControls.MoveCursor.canceled += ctx => OnMovementInput(Vector2.zero);
        playerControls.GameControls.Select.performed += OnSelectInput;
    }

    private void OnDisable()
    {
        playerControls.GameControls.Disable();

        playerControls.GameControls.MoveCursor.performed -= ctx => OnMovementInput(ctx.ReadValue<Vector2>());
        playerControls.GameControls.MoveCursor.performed -= ctx => enableMouseTracking = false;
        playerControls.GameControls.MoveCursor.canceled -= ctx => OnMovementInput(Vector2.zero);
        playerControls.GameControls.Select.performed -= OnSelectInput;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCursor();
    }

    private void MoveCursor()
    {
        //If there's a mouse cursor
        if (Input.mousePresent)
        {
            currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            //If mouse tracking disabled (happens when another mouse movement input is used)
            if (!enableMouseTracking)
            {
                //re-enable it if the mouse moved
                enableMouseTracking = MouseHasMovedSinceLastFrame();
            }
            if (enableMouseTracking)
            {
                //If the mouse tracking is enabled, the cursor move toward the mouse.
                movement = DirectionToMouse();
            }

            lastMousePos = currentMousePos;
        }
        transform.Translate(movement * movementSpeed * Time.deltaTime);
    }

    private Vector2 DirectionToMouse()
    {
        Vector2 pos2D = transform.position;
        Vector2 direction = (currentMousePos - pos2D);
        if (Vector2.Distance(pos2D, currentMousePos) > 0.1f)
        {
            return direction.normalized;
        }
        else
        {
            return Vector2.zero;
        }
    }

    private bool MouseHasMovedSinceLastFrame()
    {
        return (currentMousePos - lastMousePos).magnitude > 0.01f;
    }

    public void OnMovementInput(Vector2 movementInput)
    {
        movement = movementInput;
    }

    public void OnSelectInput(InputAction.CallbackContext ctx)
    {
        OnClick(transform.position);
    }
}
