using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSetter : MonoBehaviour
{
    [SerializeField] private ItemShop _itemShop;

    private void OnEnable()
    {
        _itemShop.SelectedChanged += SetItem;
    }

    private void OnDisable()
    {
        _itemShop.SelectedChanged -= SetItem;
    }

    private void SetItem() => TryToSetItem();

    private bool TryToSetItem()
    {
        Debug.Log("TryToSetItem");
        var item = _itemShop.SelectedItem;
        if (!item.IsOpened) return false;

        Debug.Log("TryToSetItem2");

        DestroyAllChild();
        Instantiate(item.Prefab1, transform);
        return true;
    }

    private void DestroyAllChild()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
    }
}
