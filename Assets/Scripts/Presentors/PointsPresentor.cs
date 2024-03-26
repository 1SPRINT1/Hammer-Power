using UnityEngine;
using TMPro;

public class PointsPresentor : MonoBehaviour
{
    [SerializeField] private Points _points;
    [Space]
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _points.ValueChanged += Render;
    }

    private void OnDisable()
    {
        _points.ValueChanged -= Render;
    }

    private void Render()
    {
        float pointsToDispaly = Mathf.Round(_points.Value);
        _text.text = pointsToDispaly.ToString();
    }
}