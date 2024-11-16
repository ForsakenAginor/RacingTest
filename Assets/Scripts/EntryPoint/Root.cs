using Ashsvp;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Root : MonoBehaviour
{
    [Header("PlayerCar")]
    [SerializeField] private SimcadeVehicleController _vehicleController;
    private IPlayerInput _playerInput;

    [Header("Start race logic")]
    [SerializeField] private CameraControl _switcher;
    [SerializeField] private Button _startButton;
    [SerializeField] private Timer _timer;

    [Header("FinishLogic")]
    [SerializeField] private FinishTrigger _finishTrigger;
    [SerializeField] private RoundView _roundView;

    [Header("Ghost racer logic")]
    [SerializeField] private CarRecorder _carRecorder;
    [SerializeField] private GhostCar _ghost;

    private void Start()
    {
        _playerInput = new OldInputProvider();
        _vehicleController.Init(_playerInput);

        RoundCounter roundCounter = new RoundCounter(_finishTrigger);
        _roundView.Init(roundCounter);

        _timer.TimerEnded += OnStartTimerEnded;
        _startButton.onClick.AddListener(OnStartButtonClick);
        _finishTrigger.RingCompleted += OnRingCompleted;
    }

    private void OnDestroy()
    {
        _timer.TimerEnded -= OnStartTimerEnded;
        _startButton.onClick.RemoveListener(OnStartButtonClick);
        _finishTrigger.RingCompleted -= OnRingCompleted;
    }

    private void OnRingCompleted()
    {
        _carRecorder.StartRecording(out Queue<KeyValuePair<Vector3, Quaternion>> oldData);
        _ghost.PlayRecordedVideo(oldData);
    }

    private void OnStartTimerEnded()
    {
        _vehicleController.StartWorking();
        _carRecorder.StartRecording(out _);
    }

    private void OnStartButtonClick()
    {
        _startButton.gameObject.SetActive(false);
        _switcher.Switch();
        _timer.StartCountdown();
    }
}
