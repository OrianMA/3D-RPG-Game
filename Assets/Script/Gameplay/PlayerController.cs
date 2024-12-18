using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _playerRenderer;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private InGameUiManager _uiManager;
    [SerializeField] private Rigidbody _playerRb;

    [Header("Movement Proprety")]
    [SerializeField] private float _speedMax;
    [SerializeField] private float _rotSpeed;
    [Range(0f, 1f)]
    [SerializeField] private float _joystickTreshold;


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
        _playerAnimator.SetFloat("Speed",1);
        _uiManager.JoystickSetPosition(Input.mousePosition);
        _initialMousePosition = Input.mousePosition;
        _isMoving = true;
    }

    private void ProcessTouchCancel(InputAction.CallbackContext context)
    {
        _playerAnimator.SetFloat("Speed",0);
        _uiManager.JoystickResetPos();
        _isMoving = false;
    }

    private void Update()
    {
        if (_isMoving)
        {
            // Set the value between 0,1, it's simule the joystickValue
            float dynamicSpeed = _uiManager.JoystickMoveInnerStick(Input.mousePosition);

            // Set the blend tree value for smooth animation
            _playerAnimator.SetFloat("Speed", dynamicSpeed);

            // Apply treshold for not better control and smotther visual
            if (dynamicSpeed < _joystickTreshold)
                return;
            

            // Get the direction wanted
            Vector3 direction = (Input.mousePosition - _initialMousePosition).normalized;

            // Apply the rotation with the joystick direction with speed
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            _playerRenderer.transform.rotation = Quaternion.Lerp(_playerRenderer.transform.rotation, Quaternion.Euler(0, angle - 180,0) , _rotSpeed * Time.deltaTime);

            // Apply speed smoothly 
            _playerRb.velocity = _playerRenderer.transform.forward * (_speedMax * dynamicSpeed);
        }
    }
}
