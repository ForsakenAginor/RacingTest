using System.Collections.Generic;
using UnityEngine;

public class GhostCar : MonoBehaviour
{
    [SerializeField] private Transform _ghost;
    [SerializeField] private float _animationSmoothing = 0.2f;

    private Queue<KeyValuePair<Vector3, Quaternion>> _data = new();
    private bool _isWorking;
    private KeyValuePair<Vector3, Quaternion> _record;

    private void FixedUpdate()
    {
        if (_isWorking == false)
            return;

        if (_data.Count == 0)
            return;

        _record = _data.Dequeue();
        _ghost.SetPositionAndRotation(_record.Key, _record.Value);
    }

    private void Update()
    {
        if (_isWorking == false)
            return;

        if (_data.Count == 0)
            return;
        
        //Smooth spykes beatween fixedupdates

        KeyValuePair<Vector3, Quaternion> nextRecord = _data.Peek();
        Vector3 position = Vector3.Lerp(_record.Key, nextRecord.Key, _animationSmoothing);
        Quaternion quaternion = Quaternion.Lerp(_record.Value, nextRecord.Value, _animationSmoothing);
        _record = new KeyValuePair<Vector3, Quaternion>(position, quaternion);
        _ghost.SetPositionAndRotation(_record.Key, _record.Value);
    }

    public void PlayRecordedVideo(Queue<KeyValuePair<Vector3, Quaternion>> data)
    {
        _isWorking = true;
        _data = data;
        _ghost.gameObject.SetActive(true);
    }
}
