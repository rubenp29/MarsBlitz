using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance = null;

    private PlayerInput inputActions = null;

    public PlayerInput GetInputActions()
    {
        return inputActions;
    }

    public void ToggleInputActionsState(bool state)
    {
        if (state)
        {
            inputActions.Enable();
        }
        else
        {
            inputActions.Disable();
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            inputActions = new PlayerInput();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CanGetInput(bool value)
    {
        if (value)
        {
            inputActions.Enable();
        }
        else
        {
            inputActions.Disable();
        }
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}