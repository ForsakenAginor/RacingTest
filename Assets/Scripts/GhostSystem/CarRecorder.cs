using System.Collections.Generic;
using UnityEngine;

public class CarRecorder : MonoBehaviour
{
    [SerializeField] private Transform _car;
    private Queue<KeyValuePair<Vector3, Quaternion>> _data = new ();
    private bool _isWorking;

    private void FixedUpdate()
    {
        if (_isWorking == false)
            return;

        _data.Enqueue(new KeyValuePair<Vector3, Quaternion>(_car.position, _car.rotation));
    }

    /// <summary>
    /// Start recording new data
    /// </summary>
    /// <param name="oldData">Data, that was recorded from past call StartRecording method</param>
    public void StartRecording(out Queue<KeyValuePair<Vector3, Quaternion>> oldData)
    {
        _isWorking = true;
        oldData = _data;
        _data = new Queue<KeyValuePair<Vector3, Quaternion>>();
    }
}