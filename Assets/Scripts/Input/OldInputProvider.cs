using UnityEngine;

public class OldInputProvider : IPlayerInput
{
    private const string Vertical = nameof(Vertical);
    private const string Horizontal = nameof(Horizontal);
    private const string Jump = nameof(Jump);

    public float GetHorizontalAxis()
    {
        return Input.GetAxis(Horizontal);
    }

    public float GetJump()
    {
        return Input.GetAxis(Jump);
    }

    public float GetVerticalAxis()
    {
        return Input.GetAxis(Vertical);
    }
}
