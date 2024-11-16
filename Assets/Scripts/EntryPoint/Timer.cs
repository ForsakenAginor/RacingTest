using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private int _startDelay;
    [SerializeField] private int _step;
    [SerializeField] private TMP_Text _text;

    public event Action TimerEnded;

    public void StartCountdown()
    {
        StartCoroutine(Count());
    }

    private IEnumerator Count()
    {
        //todo: separate view from model
        WaitForSeconds delay = new WaitForSeconds(_step);
        int iterator = _startDelay;

        while (iterator >= 0)
        {
            if (iterator == 0)
            {
                _text.text = "START";
                TimerEnded?.Invoke();
            }
            else
                _text.text = iterator.ToString();

            iterator--;
            yield return delay;
        }

        _text.gameObject.SetActive(false);
    }
}
