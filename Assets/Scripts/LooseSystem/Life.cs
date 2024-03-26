using System;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    [field: SerializeField] public int StartValue { get; private set; } = 3;
    public int CurrentValue { get; private set; }

    public event Action ValueChanged;
    public UnityEvent Deathed;

    private void Start()
    {
        Restart();
    }

    public void Decrease()
    {
        CurrentValue = Mathf.Max(CurrentValue - 1, 0);
        ValueChanged?.Invoke();
        CheachkDeath();
    }

    public void Restart()
    {
        CurrentValue = StartValue;
        ValueChanged?.Invoke();
    }

    private void CheachkDeath()
    {
        if (CurrentValue <= 0)
            Deathed?.Invoke();
    }
}
