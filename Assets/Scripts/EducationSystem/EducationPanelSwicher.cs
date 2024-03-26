using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

[System.Serializable]
public class OpenClosePanel
{
    [field: SerializeField] public bool Pause { get; private set; }
    public bool IsOpen { get; private set; }
    public UnityEvent Opened;
    public UnityEvent Closed;

    public void Open()
    {
        IsOpen = true;
        Opened?.Invoke();
    }

    public void Close()
    {
        IsOpen = false;
        Closed?.Invoke();
    }
}

public class EducationPanelSwicher : MonoBehaviour
{
    [SerializeField] private OpenClosePanel[] _panels;
    [SerializeField] private bool _startAwake = false;
    [field: SerializeField] public bool IsFinished { get; private set; }
    [SerializeField] private int _sinceIdNotGlobal = 3;
    private bool _pauseWas;
    private int _currentIndex;
    public event Action Finished;

    public UnityEvent Opened;
    public UnityEvent Closed2;
    public UnityEvent Closed;

    private void Start()
    {
        if (_startAwake)
            Next();
    }

    public void Next(int id)
    {
        Debug.Log("EducationCurrentPanel: " + _currentIndex + " but you try to on: " + id);
        if (id == _currentIndex)
            Next();
    }

    public void Next()
    {
        if (IsFinished) return;

        bool pause = false;
        if (_currentIndex > 0 )
        {
            var lastPanel = _panels[_currentIndex - 1];
            pause = lastPanel.Pause && !_pauseWas;
            if (lastPanel.IsOpen)
            {
                lastPanel.Close();
                Closed?.Invoke();
                if (_currentIndex >= _sinceIdNotGlobal)
                    Closed2?.Invoke();
            }
        }

        if (pause)
        {
            _pauseWas = true;
            return;
        }

        _pauseWas = false;

        if (_currentIndex < _panels.Length)
        {
            _panels[_currentIndex].Open();
            Opened?.Invoke();
        }

        _currentIndex++;
        if(_currentIndex > _panels.Length)
        {
            _currentIndex = _panels.Length - 1;
            IsFinished = true;
            Finished?.Invoke();
        }
    }

    public void Restart()
    {
        _currentIndex = 0;
        IsFinished = false;
    }
}
