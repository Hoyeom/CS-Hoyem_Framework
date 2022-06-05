using System;
using System.Collections;
using System.Collections.Generic;
using Content;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

public class PlayerController : MonoBehaviour, Controller.IPlayerActions
{
    private Controller _controller;
    

    private List<ControlObjectBase> _controlAbles = new List<ControlObjectBase>();


    private float clickDuration = 0.2f;
    private float clickTimer = 0;

    #region Unity Method
    
    private void OnEnable()
    {
        _controlAbles.Clear();
        if (_controller == null)
        {
            _controller = new Controller();
            _controller.Enable();
            _controller.Player.SetCallbacks(this);
        }
    }

    private void OnDisable()
    {
        _controlAbles.Clear();
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

    public void OnFire(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                clickTimer = Time.time;
                OccurFireInput(Define.PressEvent.Down);
                break;
            case InputActionPhase.Canceled:
                if(clickTimer + clickDuration > Time.time)
                    OccurFireInput(Define.PressEvent.Click); 
                OccurFireInput(Define.PressEvent.Up);
                break;
        }
    }

    #endregion

    private void OccurMouseInput(Vector2 input)
    {
        foreach (ControlObjectBase controlAble in _controlAbles)
            controlAble.MouseDelta(input);
    }
    
    private void OccurMoveInput(Vector2 input)
    {
        foreach (ControlObjectBase controlAble in _controlAbles)
            controlAble.MoveInput(input);
    }

    private void OccurFireInput(Define.PressEvent phase)
    {
        foreach (ControlObjectBase controlAble in _controlAbles)
            controlAble.FireInput(phase);
    }
    
    public void SubscribeControl(ControlObjectBase controlAble)
    {
        if (!_controlAbles.Contains(controlAble))
            _controlAbles.Add(controlAble);
    }

    public void UnsubScribeControl(ControlObjectBase controlAble)
    {
        if (!_controlAbles.Contains(controlAble))
            _controlAbles.Remove(controlAble);
    }

}