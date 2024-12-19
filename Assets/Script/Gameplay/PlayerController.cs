using BaseTemplate.Behaviours;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoSingleton<PlayerController>
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
    private bool _isEnemyAlive;
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
        if (PlayerAttack.IsEquipWeapon)
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
        if (PlayerAttack.IsEquipWeapon && EnemyManager.Instance.GetNearestEnemy(transform.position))
        {
            _playerAnimator.SetTrigger("_attack");
            _isEnemyAlive = true;
        }
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

            // Get the direction wanted
            playerLookDirection = (Input.mousePosition - _initialMousePosition).normalized;

            // Apply the rotation with the joystick direction with speed
            angleWanted = Mathf.Atan2(playerLookDirection.x, playerLookDirection.y) * Mathf.Rad2Deg;

            // Apply speed smoothly 
            _playerRb.velocity = _playerRenderer.transform.forward * (_speedMax * dynamicSpeed * Time.fixedDeltaTime);
        }
        else if (PlayerAttack.IsEquipWeapon && _isEnemyAlive)
        {
            // Set the rotation direction to the nearest enemy
            EnemyController enemyTarget = EnemyManager.Instance.GetNearestEnemy(transform.position);
            if (enemyTarget != null) {

                // Get the direction wanted
                playerLookDirection = (enemyTarget.transform.position - transform.position).normalized;
                angleWanted = Mathf.Atan2(playerLookDirection.x, playerLookDirection.z) * Mathf.Rad2Deg;
            } else
            {
                _isEnemyAlive = false;
                _playerAnimator.SetTrigger("_stopAttack");
                PlayerAttack.StopAttack();
            }
        }

        // Apply rotation with the speed 
        _playerRenderer.transform.rotation = Quaternion.Lerp(
                                                    _playerRenderer.transform.rotation,
                                                    Quaternion.Euler(0, angleWanted, 0),
                                                    _rotSpeed * Time.fixedDeltaTime);
    }


}
