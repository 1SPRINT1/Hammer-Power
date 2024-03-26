using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Items/ShopItem")]
public class ShopItem : Item
{
    [SerializeField] private Sprite Icon;
    public Sprite Icon1 => Icon;
    [SerializeField] private int Cost;
    public int Cost1 => Cost;
    public bool IsOpened;
}

public class ItemShop : ItemChooser<ItemShop2>
{
    [SerializeField] private PointsRecordSaver _saver;
    public event Action Loaded;

    private void OnEnable()
    {
        _saver.RecordChanged += BuyAll;
    }

    private void OnDisable()
    {
        _saver.RecordChanged -= BuyAll;
    }

    private void BuyAll()
    {
        Debug.Log("BuyAll");
        foreach (var x in Items)
        {
            x.IsOpened = x.Cost1 <= _saver.Record;
        }
        Loaded?.Invoke();
    }
}
