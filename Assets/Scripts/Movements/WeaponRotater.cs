using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WeaponRotater : MonoBehaviour
{
    [SerializeField] private WallJumper _wallJumper;
    [Space]
    [SerializeField] private float _speed = 500f;
    private float _currentSpeed;
    //[SerializeField] private float _angelToCollision = 20f;
    //[SerializeField] private float _horizontalSpeed = 1f;
    private Coroutine _currentRotation;

    private void OnEnable()
    {
        _wallJumper.MotionStarted += StartRotation;
        _wallJumper.MotionStoped += StopRotation;
    }

    private void OnDisable()
    {
        _wallJumper.MotionStarted -= StartRotation;
        _wallJumper.MotionStoped -= StopRotation;
    }

    private void StartRotation()
    {
        _currentSpeed = CalculateSpeedRotation();

        if (_currentRotation == null)
            _currentRotation = StartCoroutine(Rotate());
    }

    private void StopRotation()
    {
        if (_currentRotation != null)
        {
            StopCoroutine(_currentRotation);
            _currentRotation = null;
        }
    }

    private IEnumerator Rotate()
    {
        while (true)
        {
            transform.rotation *= Quaternion.Euler(0, 0, _currentSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private float CalculateSpeedRotation()
    {
        /*
        float r = 1.682f;
        float time = (GetDistanceToWall() - r) / _horizontalSpeed;
        Debug.Log("time: " + time);
        float angelToWillRotate = time * _speed;
        float finishAngel = transform.rotation.eulerAngles.z + angelToWillRotate;
        Debug.Log("ZZZ: " + transform.rotation.eulerAngles.z);
        Debug.Log("1 finishAngel: " + finishAngel);
        int a = (int)(finishAngel / 360);
        finishAngel -= a * 360f;
        Debug.Log("2 finishAngel: " + finishAngel);

        float currentAngelToCollision = _wallJumper.WallNormal.x > 0 ? _angelToCollision : -_angelToCollision;
        float offset = Mathf.DeltaAngle(currentAngelToCollision, finishAngel);
        Debug.Log("offset: " + offset);
        angelToWillRotate += offset;
        return angelToWillRotate / time;
        
        float r = 1.682f * 0.4f;
        float time = (GetDistanceToWall() - r) / _horizontalSpeed;

        float currentAngel = transform.rotation.eulerAngles.z;
        float angelToWillRotate = time * _speed;
        float finishAngel = currentAngel + angelToWillRotate;
        int a = (int)(finishAngel / 360);
        finishAngel -= a * 360f;

        float currentAngelToCollision = _wallJumper.WallNormal.x > 0 ? -_angelToCollision : _angelToCollision;
        float offset = Mathf.DeltaAngle(finishAngel, currentAngelToCollision);
        angelToWillRotate += offset;
        */
        return _speed * -Mathf.Sign(_wallJumper.WallNormal.x);
    }

    private float GetDistanceToWall()
    {
        Vector2 rayDirection = _wallJumper.WallNormal;
        LayerMask layerMask = 5;
        var raycast = Physics2D.Raycast(transform.position, rayDirection, Mathf.Infinity, layerMask);
        return raycast.distance;
    }
}
