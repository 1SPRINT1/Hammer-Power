using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/ShopItem2")]
public class ItemShop2 : Item
{
    [SerializeField] private Sprite Icon;
    public Sprite Icon1 => Icon;
    [SerializeField] private int Cost;
    public int Cost1 => Cost;
    public bool IsOpened;
}
