using DG.Tweening;
using System;
using TMPro;
using UnityEngine;

public class RoundView : MonoBehaviour
{
    [SerializeField] private TMP_Text _textField;
    [SerializeField] private float _animationDuration;

    private RoundCounter _roundCounter;

    private void OnDestroy()
    {
        _roundCounter.RoundCompleted += OnRoundCompleted;        
    }

    public void Init(RoundCounter roundCounter)
    {
        _roundCounter = roundCounter != null ? roundCounter : throw new ArgumentNullException(nameof(roundCounter));
        _roundCounter.RoundCompleted += OnRoundCompleted;
    }

    private void OnRoundCompleted(int value)
    {
        _textField.alpha = 1f;
        _textField.text = $"Round: {value}";
        _textField.DOFade(0f, _animationDuration);
    }
}
