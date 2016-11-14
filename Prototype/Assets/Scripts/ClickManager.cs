using UnityEngine;

[System.Serializable]
public class ClickManager
{
    //properties
    public float MaxTimeToClick { get { return _maxTimeToClick; } set { _maxTimeToClick = value; } }
    public float MinTimeToClick { get { return _minTimeToClick; } set { _minTimeToClick = value; } }
    public bool IsDebug { get { return _Isdebug; } set { _Isdebug = value; } }

    //property variables
    private float _maxTimeToClick = 0.60f;
    private float _minTimeToClick = 0.05f;
    private bool _Isdebug = false;

    //private variables to keep track
    private float _minCurrentTime;
    private float _maxCurrentTime;

    public bool DoubleClick()
    {
        if (Time.time >= _minCurrentTime && Time.time <= _maxCurrentTime)
        {
            if (_Isdebug)
                Debug.Log("Double Click");
            _minCurrentTime = 0;
            _maxCurrentTime = 0;
            return true;
        }
        _minCurrentTime = Time.time + MinTimeToClick; _maxCurrentTime = Time.time + MaxTimeToClick;
        return false;
    }
}