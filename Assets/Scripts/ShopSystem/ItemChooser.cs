using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField] private GameObject Prefab;
    public GameObject Prefab1 => Prefab;
}

public class ItemChooser<T> : MonoBehaviour where T : Item
{
    [SerializeField] private T[] _items;
    private int _currentIndex;
    public IReadOnlyList<T> Items => _items;
    public T SelectedItem => _items[_currentIndex];

    public event Action SelectedChanged;

    public void Forward()
    {
        Select(1);
    }

    public void Back()
    {
        Select(-1);
    }

    public virtual void Select(int offset)
    {
        _currentIndex = (_currentIndex + offset) % _items.Length;
        _currentIndex = _currentIndex < 0 ? _items.Length - 1 : _currentIndex;
        SelectedChanged?.Invoke();
    }
}
