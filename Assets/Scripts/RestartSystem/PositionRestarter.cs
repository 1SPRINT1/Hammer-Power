using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRestarter : MonoBehaviour
{
    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private void Awake()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }

    public void Restart()
    {
        transform.position = _startPosition;
        transform.rotation = _startRotation;
    }
}