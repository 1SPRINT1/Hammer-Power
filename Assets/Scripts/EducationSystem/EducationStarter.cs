using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EducationStarter : MonoBehaviour
{
    [SerializeField] private PointsRecordSaver _saver;
    [SerializeField] private EducationPanelSwicher _education;

    private void OnEnable()
    {
        _saver.Loaded += Cheack;
    }

    private void OnDisable()
    {
        _saver.Loaded -= Cheack;
    }

    private void Cheack()
    {
        if (_saver.Record == 0)
            _education.Restart();
    }
}
