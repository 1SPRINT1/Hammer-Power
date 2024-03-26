using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class ShotDown : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _forceForImpulsEffect = 2f;
    public UnityEvent Thrown;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out Player _))
            return;

        Fall();

        Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());

        var contact = collision.contacts[0];
        Vector2 normal = contact.normal;
        ImpulseEffect(normal);
    }

    private void Fall()
    {
        _rigidbody.constraints = RigidbodyConstraints2D.None;
        Thrown?.Invoke();
    }

    private void ImpulseEffect(Vector2 normal)
    {
        _rigidbody.AddForce(normal * _forceForImpulsEffect, ForceMode2D.Impulse);
    }
}
