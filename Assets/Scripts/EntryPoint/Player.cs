using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _canWin;

    public bool CanWin => _canWin;

    public void BecameWinnable(bool value)
    {
        _canWin = value;
    }
}