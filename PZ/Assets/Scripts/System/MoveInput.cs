using UnityEngine;

public class MoveInput : IMoveInput
{
    private readonly Joystick _joystick;

    public MoveInput(Joystick joystick)
    {
        _joystick = joystick;
    }

    public Vector2 GetDirection()
    {
        Vector2 direction = Vector2.zero;

        direction.x = _joystick.Horizontal;
        direction.y = _joystick.Vertical;

        return direction;
    }
}
