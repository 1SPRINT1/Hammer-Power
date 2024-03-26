using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplaerSpeedPointsPresentor : MonoBehaviour
{
    [SerializeField] private PointsSpeedMultiplier _multiplierPoints;
    [Space]
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _multiplierPoints.ValueChanged += Render;
    }

    private void OnDisable()
    {
        _multiplierPoints.ValueChanged -= Render;
    }

    private void Render()
    {
        _slider.value = _multiplierPoints.Value;
    }
}
