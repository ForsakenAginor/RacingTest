using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _observerCamera;

    private void Start()
    {
        CinemachineCore.GetInputAxis = GetAxisCustom;
    }

    public void Switch()
    {
        _observerCamera.Priority = 0;
    }

    private float GetAxisCustom(string inputAxis)
    {
        const string MouseXInput = "test";
        const float Speed = 0.1f;

        if (inputAxis == MouseXInput)
            return Speed;

        return 0;
    }
}
