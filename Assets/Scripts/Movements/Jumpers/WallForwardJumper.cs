using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallForwardJumper : WallDoubleJumper
{
    [SerializeField] private float _angel = 45f;
    [SerializeField] private float _speed = 2f;
    private Vector2 _currentVelocity;

    private void Start()
    {
        Rigidbody2D.gravityScale = 0f;
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = _currentVelocity;
    }

    protected override void JumpLeft() => Jump(-1);

    protected override void JumpRight() => Jump(1);

    private void Jump(int sign)
    {
        Debug.Log("Jump: " + sign);
        if (Mathf.Abs(sign) != 1)
            throw new System.Exception("sign is not sign: " + sign);

        _currentVelocity = Quaternion.Euler(0, 0, _angel * sign) * Vector2.right * sign * _speed;
        Debug.Log(_currentVelocity);
    }
}
