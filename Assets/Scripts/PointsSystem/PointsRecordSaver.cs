using System;
using UnityEngine;

public class PointsRecordSaver : MonoBehaviour
{
    [SerializeField] private Points _points;
    private const string KEY = "RECORD1";
    public float Record { get; private set; }

    public event Action Loaded;
    public event Action RecordChanged;

    private void Awake()
    {
        Load(Loaded);
        RecordChanged?.Invoke();
    }

    private void OnEnable()
    {
        _points.ValueChanged += CheackRecord;
    }

    private void OnDisable()
    {
        _points.ValueChanged -= CheackRecord;
    }

    private void CheackRecord()
    {
        float currentValue = _points.Value;
        if(currentValue > Record)
        {
            Record = currentValue;
            Save(Record);
            RecordChanged?.Invoke();
        }
    }

    [ContextMenu("ResetRecord")]
    public void ResetRecord()
    {
        Record = 0;
        Save(Record);
        RecordChanged?.Invoke();
    }

    protected virtual void Save(float value) => PlayerPrefs.SetFloat(KEY, value);
    protected virtual void Load(Action loaded)
    {
        if (!PlayerPrefs.HasKey(KEY))
        {
            loaded?.Invoke();
            return;
        }

        Record = PlayerPrefs.GetFloat(KEY);
        loaded?.Invoke();
    }
}
