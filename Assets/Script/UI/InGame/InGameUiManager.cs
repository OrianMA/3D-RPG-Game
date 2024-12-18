using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUiManager : MonoBehaviour
{
    [Header("JoyStick")]
    [SerializeField] private RectTransform _joystickParent;
    [SerializeField] private RectTransform _innerStick;
    [SerializeField] private float _innerStickMaxOffset;



    // JoyStick value
    // 2 Pos for reset Joystick pos on cancel click
    private Vector3 _intialJoyStickPos;
    private Vector3 _intialInnerStickPos;

    // Use to clamp the position of innerstick
    private Vector3 _newInitialInnerStickPos;

    private void Start()
    {
        // Set base joystick position
        _intialJoyStickPos = _joystickParent.transform.localPosition;
        _intialInnerStickPos = _innerStick.transform.localPosition;
    }
    public void JoystickSetPosition(Vector3 position)
    {
        // Set new position of the joystick (on click)
        _joystickParent.transform.position = position;
        _newInitialInnerStickPos = _innerStick.transform.position;
    }

    public void JoystickResetPos()
    {
        // Reset the position to initial
        _joystickParent.transform.localPosition = _intialJoyStickPos;
        _innerStick.transform.localPosition = _intialInnerStickPos;
    }

    public void JoystickMoveInnerStick(Vector3 position)
    {
        // Get the direction of the mouse
        Vector3 direction = position - _newInitialInnerStickPos;

        if (direction.magnitude > _innerStickMaxOffset)
        {
            // Clamp the InnerStick  with a max distance
            direction = direction.normalized * _innerStickMaxOffset;
        }

        Vector3 newInnerStickPos = _newInitialInnerStickPos + direction;
        newInnerStickPos.z = 0; // Make sur the Z axis stay here

        // Set the new positon;
        _innerStick.transform.position = newInnerStickPos;
    }
}
