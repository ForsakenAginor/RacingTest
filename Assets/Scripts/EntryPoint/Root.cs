using Ashsvp;
using UnityEngine;
using UnityEngine.UI;

public class Root : MonoBehaviour
{
    [SerializeField] private SimcadeVehicleController _vehicleController;
    [SerializeField] private CameraControl _switcher;
    [SerializeField] private Button _startButton;
    [SerializeField] private Timer _timer;
    [SerializeField] private FinishTrigger _finishTrigger;

    private IPlayerInput _playerInput;

    [Header("Debug")]
    [SerializeField] private Button _button;
    private int _index = 0;


    private void Start()
    {
        _playerInput = new OldInputProvider();
        _vehicleController.Init(_playerInput);

        _timer.TimerEnded += OnStartTimerEnded;
        _button.onClick.AddListener(OnButtonClick);
        _startButton.onClick.AddListener(OnStartButtonClick);
        _finishTrigger.RingCompleted += OnRingCompleted;
    }

    private void OnDestroy()
    {
        _timer.TimerEnded -= OnStartTimerEnded;
        _button.onClick.RemoveListener(OnButtonClick);
        _startButton.onClick.RemoveListener(OnStartButtonClick);
        _finishTrigger.RingCompleted -= OnRingCompleted;
    }

    private void OnRingCompleted()
    {
        Debug.Log($"Rings complete: {++_index}");
    }

    private void OnStartTimerEnded()
    {
        _vehicleController.StartWorking();
    }

    private void OnStartButtonClick()
    {
        _startButton.gameObject.SetActive(false);
        _switcher.Switch();
        _timer.StartCountdown();
    }

    private void OnButtonClick()
    {
        _switcher.Switch();
    }
}
