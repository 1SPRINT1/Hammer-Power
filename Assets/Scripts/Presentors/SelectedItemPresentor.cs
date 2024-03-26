using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class SelectedItemPresentor : MonoBehaviour
{
    [SerializeField] private ItemShop _shop;
    [Space]
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _text;

    public UnityEvent Closed;
    public UnityEvent Opened;

    private void OnEnable()
    {
        _shop.SelectedChanged += Render;
        _shop.Loaded += Render;
    }

    private void OnDisable()
    {
        _shop.SelectedChanged -= Render;
        _shop.Loaded -= Render;
    }

    private void Render()
    {
        var item = _shop.SelectedItem;
        _image.sprite = item.Icon1;
        _text.text = item.Cost1.ToString();

        if (item.IsOpened)
            Opened?.Invoke();
        else
            Closed?.Invoke();
    }
}
