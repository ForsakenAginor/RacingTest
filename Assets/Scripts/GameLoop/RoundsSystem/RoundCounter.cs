using System;

public class RoundCounter
{
    private readonly FinishTrigger _finish;
    private int _round = 1;

    public RoundCounter(FinishTrigger finish)
    {
        _finish = finish != null ? finish : throw new ArgumentNullException(nameof(finish));
        _finish.RingCompleted += OnRingCompleted;
    }

    ~RoundCounter()
    {
        _finish.RingCompleted += OnRingCompleted;
    }

    public event Action<int> RoundCompleted;

    public int Round => _round;

    private void OnRingCompleted()
    {
        RoundCompleted?.Invoke(++_round);
    }
}
