using System;
using System.Collections;
using System.Collections.Generic;
using Content;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, Controller.IPlayerActions
{
    private Controller _controller;
    

    private List<ControlObjectBase> controlObjects = new List<ControlObjectBase>();
    

    #region Unity Method
    
    private void OnEnable()
    {
        controlObjects.Clear();
        if (_controller == null)
        {
            _controller = new Controller();
            _controller.Enable();
            _controller.Player.SetCallbacks(this);
        }
    }

    private void OnDisable()
    {
        controlObjects.Clear();
        if (_controller != null)
        {
            _controller.Disable();
            _controller = null;
        }
    }
    

    #endregion

    #region Input
    
    public void OnMouseDelta(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                OccurMouseInput(context.ReadValue<Vector2>());
                break;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
            case InputActionPhase.Canceled:
                OccurMoveInput(context.ReadValue<Vector2>());
                break;
        }
    }
    

    #endregion

    private void OccurMouseInput(Vector2 input)
    {
        foreach (ControlObjectBase controlAble in controlObjects)
            controlAble.MouseDelta(input);
    }
    
    private void OccurMoveInput(Vector2 input)
    {
        input.Normalize();
        foreach (ControlObjectBase controlAble in controlObjects)
            controlAble.MoveInput(input);
    }

    public void SubscribeControl(ControlObjectBase controlAble)
    {
        if (!controlObjects.Contains(controlAble))
            controlObjects.Add(controlAble);
    }

    public void UnsubScribeControl(ControlObjectBase controlAble)
    {
        if (!controlObjects.Contains(controlAble))
            controlObjects.Remove(controlAble);
    }

}