using UnityEngine;
using UnityEngine.Events;

public class WallTrigger : MonoBehaviour
{
    public UnityEvent Triggered;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Wall _))
            Triggered?.Invoke();
    }
}
