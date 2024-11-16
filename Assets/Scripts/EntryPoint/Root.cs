using Ashsvp;
using UnityEngine;
using UnityEngine.UI;

public class Root : MonoBehaviour
{
    [SerializeField] private SimcadeVehicleController _vehicleController;
    [SerializeField] private CameraControl _switcher;
    [SerializeField] private Button _startButton;
    [SerializeField] private Timer _timer;

    [Header("Debug")]
    [SerializeField] private Button _button;

    private IPlayerInput _playerInput;

    private void Start()
    {
        _playerInput = new OldInputProvider();
        _vehicleController.Init(_playerInput);

        _timer.TimerEnded += OnStartTimerEnded;
        _button.onClick.AddListener(OnButtonClick);
        _startButton.onClick.AddListener(OnStartButtonClick);
    }

    private void OnDestroy()
    {
        _timer.TimerEnded -= OnStartTimerEnded;
        _button.onClick.RemoveListener(OnButtonClick);
        _startButton.onClick.RemoveListener(OnStartButtonClick);
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

public interface IPlayerInput
{
    public float GetVerticalAxis(); 

    public float GetHorizontalAxis(); 

    public float GetJump(); 
}

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
