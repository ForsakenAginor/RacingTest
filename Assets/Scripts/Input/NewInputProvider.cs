using System;
using UnityEngine;

public class NewInputProvider : IPlayerInput
{
    private readonly InputActions _actions;

    public NewInputProvider(InputActions actions)
    {
        _actions = actions != null ? actions : throw new ArgumentNullException(nameof(actions));
    }

    public float GetHorizontalAxis()
    {
        return _actions.Player.Move.ReadValue<Vector2>().x;
    }

    public float GetJump()
    {
        return _actions.Player.Jump.ReadValue<float>();
    }

    public float GetVerticalAxis()
    {
        return _actions.Player.Move.ReadValue<Vector2>().y;
    }
}
