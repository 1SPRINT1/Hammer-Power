using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecordPresentor : MonoBehaviour
{
    [SerializeField] private PointsRecordSaver _saver;
    [Space]
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _saver.RecordChanged += Render;
        Render();
    }

    private void OnDisable()
    {
        _saver.RecordChanged -= Render;
    }

    private void Render()
    {
        _text.text = Mathf.Round(_saver.Record).ToString();
    }
}
