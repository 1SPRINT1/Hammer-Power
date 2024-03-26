using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoreOpener : MonoBehaviour
{
    [SerializeField] private bool _showOnAwake = true;

    public UnityEvent Opened;
    public UnityEvent Closed;

    public UnityEvent Showed;
    public UnityEvent Offed;

    private bool _isOn;
    private bool _isOpened;

    private void Start()
    {
        if(_showOnAwake)
            Show();
    }

    public void OpenClose()
    {
        Debug.Log("Ooo");
        if (_isOpened)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    public void Forward()
    {
        if (!_isOn && !_isOpened)
        {
            Show();
            return;
        }

        if (!_isOpened)
        {
            Open();
            return;
        }
    }

    public void Back()
    {
        if (_isOpened && _isOn)
        {
            Close();
            return;
        }

        if (_isOn)
        {
            Off();
            return;
        }
    }

    public void Show()
    {
        _isOn = true;
        Showed?.Invoke();
    }

    public void Off()
    {
        if (!_isOn) return;
        if (_isOpened) return;

        _isOn = false;
        Offed?.Invoke();
    }

    public void Open()
    {
        if (!_isOn) return;

        Debug.Log("Opened");
        _isOpened = true;
        Opened?.Invoke();
    }

    public void Close()
    {
        if (!_isOpened) return;

        _isOpened = false;
        Closed?.Invoke();
    }
}
