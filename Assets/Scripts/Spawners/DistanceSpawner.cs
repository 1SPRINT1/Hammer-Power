using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [Space]
    [SerializeField] private Vector2 _offset;
    [SerializeField] private int _startCount = 3;
    private Transform _lastSpawnedObject;

    private void Start()
    {
        Resrtart();
    }

    public void Resrtart()
    {
        DestroyAll();
        _lastSpawnedObject = null;
        Spawn(_startCount);
    }

    public void Spawn()
    {
        Vector2 positionToSpawn = _lastSpawnedObject == null ? transform.position : _lastSpawnedObject.position + (Vector3)_offset;
        _lastSpawnedObject = Instantiate(_prefab, positionToSpawn, _prefab.transform.rotation, transform).transform;
    }

    private void Spawn(int count)
    {
        for (int i = 0; i < count; i++)
            Spawn();
    }

    private void DestroyAll()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
    }
}