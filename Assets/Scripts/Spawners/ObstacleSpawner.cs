using UnityEngine;
using UnityEngine.Events;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Transform[] _points;
    public UnityEvent Spawned;

    private void OnEnable()
    {
        Spawn();
    }

    private void Spawn()
    {
        Vector2 spawnPoint = _points[Random.Range(0, _points.Length)].position;
        var selcted = _prefabs[Random.Range(0, _prefabs.Length)];
        var spawned = Instantiate(selcted, spawnPoint, Quaternion.identity);
        spawned.transform.SetParent(transform);

        Spawned?.Invoke();
    }
}