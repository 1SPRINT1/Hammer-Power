using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class WallJumper : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Collider2D _collider2D;

    public bool IsInAir { get; private set; }
    public Vector2 WallNormal { get; private set; } = Vector2.left;
    protected Rigidbody2D Rigidbody2D { get; private set; }
    private RigidbodyConstraints2D _startConstraints;

    public event Action MotionStarted;
    public event Action MotionStoped;

    private void OnEnable()
    {
        _input.Touched += OnTouched;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        _startConstraints = Rigidbody2D.constraints;
    }

    private void OnDisable()
    {
        _input.Touched -= OnTouched;
    }

    private void OnTouched()
    {
        Debug.Log("OnTouched");
        StartMoution();
        TryToJump();
    }

    protected abstract bool TryToJump();

    protected abstract void JumpRight();
    protected abstract void JumpLeft();

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!enabled) return;

        if (collision.TryGetComponent(out Wall _))
            _collider2D.isTrigger = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!enabled) return;

        if (IsWall(collision))
        {
            IsInAir = false;
            WallNormal = collision.contacts[0].normal;
            StopMoution();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!enabled) return;

        if (IsWall(collision))
        {
            IsInAir = true;
            //_collider2D.isTrigger = true;
        }
    }

    private bool IsWall(Collision2D collision)
        => collision.gameObject.TryGetComponent(out Wall _);

    private void StopMoution()
    {
        Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        MotionStoped?.Invoke();
    }

    private void StartMoution()
    {
        Rigidbody2D.constraints = _startConstraints;
        MotionStarted?.Invoke();
    }
}
