using UnityEngine;
using UnityEngine.Events;

public class Waiter : MonoBehaviour
{
    [SerializeField] private float _time = 0.3f;
    public UnityEvent Actioned;

    private void OnEnable()
    {
        Invoke(nameof(Action), _time);
    }

    private void Action() => Actioned?.Invoke();
}
