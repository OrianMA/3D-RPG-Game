using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private InGameUiManager _uiManager;

    // Private variable for movement
    private GameInputAction _playerInp;
    private Vector3 _initialMousePosition;

    private bool _isMoving;

    private void Start()
    {
        // Set input player and enable it
        _playerInp = new GameInputAction();

        _playerInp.Player.Move.started += ProcessTouchStart;
        _playerInp.Player.Move.canceled += ProcessTouchCancel;

        _playerInp.Enable();
    }


    private void ProcessTouchStart(InputAction.CallbackContext context)
    {
        _playerAnimator.SetInteger("Speed",1);
        _uiManager.JoystickSetPosition(Input.mousePosition);
        _initialMousePosition = Input.mousePosition;
        _isMoving = true;
    }

    private void ProcessTouchCancel(InputAction.CallbackContext context)
    {
        _playerAnimator.SetInteger("Speed",0);
        _uiManager.JoystickResetPos();
        _isMoving = false;
    }

    private void Update()
    {
        if (_isMoving)
        {
            _uiManager.JoystickMoveInnerStick(Input.mousePosition);

        }
    }
}
