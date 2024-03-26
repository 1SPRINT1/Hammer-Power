using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamagerTrigger : MonoBehaviour
{
    public UnityEvent Damaged;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Damager _))
            Damaged?.Invoke();
    }
}