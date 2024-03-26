using UnityEngine;

public class LifePresentor : MonoBehaviour
{
    [SerializeField] private Life _life;
    [Space]
    [SerializeField] private GameObject _heartPrefab;

    private void OnEnable()
    {
        _life.ValueChanged += Render;
    }

    private void OnDisable()
    {
        _life.ValueChanged -= Render;
    }

    private void Render()
    {
        DestroyAllChildren();
        Spawn(_life.CurrentValue);
    }

    private void DestroyAllChildren()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
    }

    private void Spawn(int count)
    {
        for (int i = 0; i < count; i++)
            Instantiate(_heartPrefab, transform);
    }
}
