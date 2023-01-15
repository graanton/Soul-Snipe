using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInput : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private MovementBehaviour _movement;

    private void Update()
    {
        Vector2 direction = _joystick.Direction;

        if (direction.magnitude > 0)
        {
            _movement.Move(direction);
        }
    }
}
