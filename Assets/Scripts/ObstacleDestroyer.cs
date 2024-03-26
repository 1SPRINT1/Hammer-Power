using UnityEngine;
using UnityEngine.Events;

public class ObstacleDestroyer : MonoBehaviour
{
    public UnityEvent Destroyed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out ObjectToDestroy _))
        {
            Destroy(collision.gameObject);
            Destroyed?.Invoke();
        }
    }
}
