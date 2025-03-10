﻿using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class FinishTrigger : MonoBehaviour
{
    public event Action RingCompleted;

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))        
            player.SetCanWin(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player) && player.CanWin)
            RingCompleted?.Invoke();        
    }
}
