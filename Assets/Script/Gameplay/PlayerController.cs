using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _playerRenderer;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private InGameUiManager _uiManager;
    [SerializeField] private Rigidbody _playerRb;
    public PlayerAttack PlayerAttack;

    [Header("Movement Proprety")]
    [SerializeField] private float _speedMax;
    [SerializeField] private float _rotSpeed;
    [Range(0f, 1f)]
    [SerializeField] private float _joystickTreshold;


    // Private variable for movement
    private GameInputAction _playerInp;
    private Vector3 _initialMousePosition;


    private bool _isMoving;
    Vector3 playerLookDirection = new Vector3();
    float angleWanted;

    private void Start()
    {
        // Set input player and enable it
        _playerInp = new GameInputAction();

        _playerInp.Player.Move.started += ProcessTouchStart;
        _playerInp.Player.Move.canceled += ProcessTouchCancel;

        _playerInp.Enable();
    }

    #region Player Input
    private void ProcessTouchStart(InputAction.CallbackContext context)
    {
        //  set joystick position, add start moving
        _uiManager.JoystickSetPosition(Input.mousePosition);
        _initialMousePosition = Input.mousePosition;
        _isMoving = true;

        // Is plauyer attack before, force stop the attack
        if (PlayerAttack.IsAttack)
        {
            PlayerAttack.StopAttack();
        }
    }

    private void ProcessTouchCancel(InputAction.CallbackContext context)
    {
        // Reset animation and joystick
        _playerAnimator.SetFloat("Speed",0);
        _uiManager.JoystickResetPos();
        _isMoving = false;

        // ATTACK ! (animation)
        if (PlayerAttack.IsEquipWeapon)
            _playerAnimator.SetTrigger("_attack");
    }

    #endregion

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
            
            playerLookDirection = (Input.mousePosition - _initialMousePosition).normalized;

            // Apply the rotation with the joystick direction with speed
            angleWanted = Mathf.Atan2(playerLookDirection.x, playerLookDirection.y) * Mathf.Rad2Deg;

            // Apply speed smoothly 
            _playerRb.velocity = _playerRenderer.transform.forward * (_speedMax * dynamicSpeed);
        }
        else if (PlayerAttack.IsEquipWeapon)
        {
            // Set the rotation direction to the nearest enemy
            playerLookDirection = (EnemyManager.Instance.GetNearestEnemy(transform.position).transform.position - transform.position).normalized;
            angleWanted = Mathf.Atan2(playerLookDirection.x, playerLookDirection.z) * Mathf.Rad2Deg;
        }
        // Get the direction wanted


        _playerRenderer.transform.rotation = Quaternion.Lerp(
                                                    _playerRenderer.transform.rotation,
                                                    Quaternion.Euler(0, angleWanted, 0),
                                                    _rotSpeed * Time.deltaTime
);
    }


}
