using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Restarter : MonoBehaviour
{
    [SerializeField] private Points _points;
    [SerializeField] private WallJumper _wallJumper;
    [SerializeField] private PositionRestarter _positionRestarter;
    [SerializeField] private DistanceSpawner _distanceSpawner;
    [SerializeField] private float _delay = 1f;
    [SerializeField] private Life _life;
    [SerializeField] private StoreOpener _storeOpener;
    public UnityEvent Restarted1;
    public UnityEvent Restarted2;

    public void Restart()
    {
        StartCoroutine(Play());
    }

    private IEnumerator Play()
    {
        //_wallJumper.enabled = false;
        _positionRestarter.Restart();
        _points.Restart();
        _distanceSpawner.Resrtart();
        Restarted1?.Invoke();
        yield return new WaitForSeconds(_delay);
        _life.Restart();
        _storeOpener.Show();
        //_wallJumper.enabled = true;
        Restarted2?.Invoke();
    }
}
